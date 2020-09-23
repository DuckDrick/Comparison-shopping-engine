using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Comparison_shopping_engine
{
    class Scraper2
    {
        private string url;
        private RichTextBox results;

        public Scraper2()
        {
        }

        public Scraper2(string url, RichTextBox results)
        {
            this.url = url;
            this.results = results;
        }

        public async void startScraping( string url, RichTextBox results)
        {
            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);
            var htmlDocument = new HtmlAgilityPack.HtmlDocument();
            htmlDocument.LoadHtml(html);

            var productHtml = htmlDocument.DocumentNode.Descendants("li")
                .Where(node => node.GetAttributeValue("class", "")
                .Contains("category-item ajax_block_product " +
                "col-xs-12 col-sm-6 col-md-4 col-lg-3")).ToList();

            List<Product> products = new List<Product>();
            foreach( var Product in productHtml)
            {
                //to add database for products maybe
                results.AppendText(HtmlEntity.DeEntitize(Product.Descendants("a")
                .Where(node => node.GetAttributeValue("class", "")
                .Equals("product-name")).FirstOrDefault().InnerText + Product.Descendants("span")
                .Where(node => node.GetAttributeValue("class", "")
                .Equals("price product-price")).FirstOrDefault().InnerText) +  " - Bigbox.lt\n");

            }

            var nextPage = htmlDocument.DocumentNode.Descendants("li")
                .Where(node => node.GetAttributeValue("id", "")
                .Equals("pagination_next_bottom")).LastOrDefault();
            if (nextPage != null && nextPage.Attributes["class"].Value != "disabled pagination_next")
            {
                string href = HtmlEntity.DeEntitize(nextPage.Descendants("a").First().Attributes["href"].Value);
                if (href != null)
                {
                    startScraping("https://bigbox.lt" + href, results);
                }
            }
            
            
        }


    }
}
