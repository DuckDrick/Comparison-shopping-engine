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
        private readonly ListView results;

        public Scraper2()
        {
        }

        public Scraper2(ListView results)
        {
            this.results = results;
        }

        public async Task StartScraping( string url, List<Product> productsList)
        {
            var bigboxUrl = "https://bigbox.lt/paieska?controller=search&orderby=position&orderway=desc&ssa_submit=&search_query=" + url;
            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(bigboxUrl);
            var htmlDocument = new HtmlAgilityPack.HtmlDocument();
            htmlDocument.LoadHtml(html);

            var productHtml = htmlDocument.DocumentNode.Descendants("li")
                .Where(node => node.GetAttributeValue("class", "")
                .Contains("category-item ajax_block_product " +
                "col-xs-12 col-sm-6 col-md-4 col-lg-3")).ToList();

            foreach( var Product in productHtml)
            {
                //to add database for products maybe
               var name = HtmlEntity.DeEntitize(Product.Descendants("a")
                .Where(node => node.GetAttributeValue("class", "")
                .Equals("product-name")).FirstOrDefault().InnerText).Trim();

                var price = Product.Descendants("span")
                .Where(node => node.GetAttributeValue("class", "")
                .Equals("price product-price")).FirstOrDefault().InnerText.Trim();
                price.Replace(",", ".");

                var producturl =HtmlEntity.DeEntitize(Product.Descendants("a")
                .Where(node => node.GetAttributeValue("class", "")
                 .Equals("category-item-image")).FirstOrDefault().Attributes["href"].Value).Trim();

                var productImageUrl = HtmlEntity.DeEntitize(Product.Descendants("img")
                    .Where(node => node.GetAttributeValue("class", "")
                        .Equals("replace-2x img-responsive")).FirstOrDefault().Attributes["src"].Value);


                var httpClientp = new HttpClient();
                var htmlp = await httpClientp.GetStringAsync(producturl);
                var htmlDocumentp = new HtmlAgilityPack.HtmlDocument();
                htmlDocumentp.LoadHtml(htmlp);

                var group = HtmlEntity.DeEntitize(htmlDocumentp.DocumentNode.Descendants("span")
                .Where(node => node.GetAttributeValue("class", "")
                .Equals("navigation_page")).FirstOrDefault().Descendants("a").ToList()[1].InnerText).Trim();

                string[] row = {name, price, "bigbox.lt"};
                var item = new ListViewItem(row);
                results.Items.Add(item);
                productsList.Add(new Product(name, price, producturl, productImageUrl, group));
            }

            var nextPage = htmlDocument.DocumentNode.Descendants("li")
                .Where(node => node.GetAttributeValue("id", "")
                .Equals("pagination_next_bottom")).LastOrDefault();
            if (nextPage != null && nextPage.Attributes["class"].Value != "disabled pagination_next")
            {
                string href = HtmlEntity.DeEntitize(nextPage.Descendants("a").First().Attributes["href"].Value);
                if (href != null)
                {
                    await StartScraping("https://bigbox.lt" + href, productsList);
                }
            }
            
            
        }


    }
}
