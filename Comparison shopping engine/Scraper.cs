using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using Comparison_shopping_engine;
public class Scraper
{
    private readonly ListView results;
    private Database db;
    public Scraper(ListView results, Database db)
    {
        this.results = results;
        this.db = db;
    }

    private string pages = null;

 
    public async Task Scrape(string url, List<Product> productsList)
    {
        var urlrde = "https://www.rde.lt/search_result/lt/word/" + url + "/page/";
        pages = null;
        try
        {
            await GetHtmlAsync(urlrde + "1", productsList);
            int s = 1;
            if (!(pages is null))
            {
                s = int.Parse(pages);
            }
            for (int i = 2; i <= s; i++)
            {
                await GetHtmlAsync(urlrde + i.ToString(), productsList);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public async Task GetHtmlAsync(string url, List<Product> productsList)
    {
        var httpClient = new HttpClient();
        var html = await httpClient.GetStringAsync(url);

        var htmlDocument = new HtmlAgilityPack.HtmlDocument();

        htmlDocument.LoadHtml(html);


        if (pages is null)
        {
            var des = htmlDocument.DocumentNode.Descendants("div")
            .Where(node => node.GetAttributeValue("class", "")
            .Equals("pages")).LastOrDefault().Descendants("a").LastOrDefault();
            if (des != null)
            {
                pages = des.InnerText;
            }
            else
            {
                pages = "1";
            }
        }

        var ProductList = htmlDocument.DocumentNode.Descendants("div")
            .Where(node => node.GetAttributeValue("class", "")
            .Equals("product_box_div")).ToList();

        Regex rgx = new Regex("[^(\\d+\\.\\d+)]");
        foreach (var Product in ProductList)
        {
            var name = HtmlEntity.DeEntitize(Product.Descendants("div")
                .Where(node => node.GetAttributeValue("class", "")
                .Equals("product_name")).FirstOrDefault().InnerText).Trim();
            var price = rgx.Replace(Product.Descendants("div")
                .Where(node => node.GetAttributeValue("class", "")
                .Contains("product_price")).FirstOrDefault().InnerText, "").Trim();
            var productUrl = "https://www.rde.lt/"+HtmlEntity.DeEntitize(Product.Descendants("a")
                .FirstOrDefault().Attributes["href"].Value).Trim();
            var productImageUrl = "https://www.rde.lt/" + Product.Descendants("img")
                .Where(node => node.GetAttributeValue("class", "")
                    .Equals("product_photo_grid")).FirstOrDefault().Attributes["src"].Value;

            //if (!db.checkIfExists("rde", name).Result)
            if (!Database.Search(name.Replace("'", "''"), "rde"))
            {
                var httpClientp = new HttpClient();
                var htmlp = await httpClientp.GetStringAsync(productUrl);
                var htmlDocumentp = new HtmlAgilityPack.HtmlDocument();
                htmlDocumentp.LoadHtml(htmlp);

                var group = HtmlEntity.DeEntitize(htmlDocumentp.DocumentNode.Descendants("li")
                    .Where(node => node.GetAttributeValue("class", "")
                    .Equals("selected_menu")).FirstOrDefault().InnerText).Trim();

                productsList.Add(new Product(name, price + " €‎", productUrl, productImageUrl, group, "rde"));
                string[] row = { name, price‎ + " €‎", "rde.lt" };
                var item = new ListViewItem(row);
                results.Items.Add(item);
                try
                {
                    db.addOrUpdate("rde", name.Replace("'", "''"), group, productUrl, productImageUrl.Trim(), price.Replace(",", ".").Replace(" ", "").Trim());
                }
                catch (Exception e)
                {
                    Console.WriteLine("------RDE-------");
                    Console.WriteLine(name);
                    Console.WriteLine(price);
                    Console.WriteLine(productUrl);
                    Console.WriteLine(productImageUrl);
                    Console.WriteLine(group);
                    Console.WriteLine(e);
                }
            }
        }


    }
}
