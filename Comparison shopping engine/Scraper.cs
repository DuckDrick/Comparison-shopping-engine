using HtmlAgilityPack;
using System;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

public class Scraper
{
    private RichTextBox results;
    public Scraper(string url, RichTextBox results)
    {
        t(url);
        this.results = results;
    }

    private static string pages = null;


    private async void t(string url)
    {
        await GetHtmlAsync(url + "1");
        int s = 1;
        if (!(pages is null))
        {
            s = int.Parse(pages);
        }
        for (int i = 2; i <= s; i++)
        {
            await GetHtmlAsync(url + i.ToString());
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
            pages = htmlDocument.DocumentNode.Descendants("div")
            .Where(node => node.GetAttributeValue("class", "")
            .Equals("pages")).LastOrDefault().Descendants("a").LastOrDefault().InnerText;
            Console.WriteLine(pages);
        }

        var ProductList = htmlDocument.DocumentNode.Descendants("div")
            .Where(node => node.GetAttributeValue("class", "")
            .Equals("product_box_div")).ToList();

        Regex rgx = new Regex("[^(\\d+\\.\\d+)]");
        foreach (var Product in ProductList)
        {
            results.AppendText(Product.Descendants("div")
                .Where(node => node.GetAttributeValue("class", "")
                .Equals("product_name")).FirstOrDefault().InnerText + " " +
                rgx.Replace(Product.Descendants("div")
                .Where(node => node.GetAttributeValue("class", "")
                .Contains("product_price")).FirstOrDefault().InnerText, "") + "\n");
        }


    }
}
