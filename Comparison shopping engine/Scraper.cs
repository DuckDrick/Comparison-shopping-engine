using HtmlAgilityPack;
using System;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

public class Scraper
{
    private readonly ListView results;
    public Scraper(ListView results)
    {
        this.results = results;
    }

    private string pages = null;

 
    public async void Scrape(string url)
    {
        var urlrde = "https://www.rde.lt/search_result/lt/word/" + url + "/page/";
        pages = null;
        try
        {
            await GetHtmlAsync(urlrde + "1");
            int s = 1;
            if (!(pages is null))
            {
                s = int.Parse(pages);
            }
            for (int i = 2; i <= s; i++)
            {
                await GetHtmlAsync(urlrde + i.ToString());
            }
        }
        catch
        {
            MessageBox.Show("Rde.lt nieko nerado");
        }
    }

    private async Task GetHtmlAsync(string url)
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
                .Equals("product_name")).FirstOrDefault().InnerText);
            var price = rgx.Replace(Product.Descendants("div")
                .Where(node => node.GetAttributeValue("class", "")
                .Contains("product_price")).FirstOrDefault().InnerText, "") + " €‎";
            string[] row = { name, price‎, "rde.lt" };
            var item = new ListViewItem(row);
            results.Items.Add(item);
        }


    }
}
