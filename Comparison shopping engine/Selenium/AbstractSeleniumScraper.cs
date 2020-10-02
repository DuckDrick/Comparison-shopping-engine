using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Comparison_shopping_engine
{
    abstract class AbstractSeleniumScraper
    {
       
        public List<Product> ScrapeWithSelenium(string search)
        {
            var products = new List<Product>();

            var options = new ChromeOptions();
            options.AddArgument("headless");
            using (var driver = new ChromeDriver(options))
            {
                string next_page = search;
                driver.Navigate().GoToUrl(next_page);

                do
                {
                    var product_list = GetProductList(driver);
                    foreach (var product in product_list)
                    {
                        if (ShouldScrape(product))
                        {
                            var (price, name, productUrl, photoUrl) = GetInfo(product);
                            products.Add(new Product(name, price, productUrl, photoUrl, "None"));
                        }
                    }

                    next_page = NextPage(driver);
                    driver.Navigate().GoToUrl(next_page);
                } while (ShouldStopScraping());

                foreach (var product in products)
                {
                    driver.Navigate().GoToUrl(product.link);
                    product.group = GetProductGroup(driver);
                }

                driver.Close();
            }

            return products;

        }

        public abstract string GetProductGroup(ChromeDriver driver);
        public abstract bool ShouldStopScraping();
        public abstract string NextPage(ChromeDriver driver);
        public abstract ReadOnlyCollection<IWebElement> GetProductList(ChromeDriver driver);
        public abstract bool ShouldScrape(IWebElement product);
        public abstract (string, string, string, string) GetInfo(IWebElement product);
    }
}
