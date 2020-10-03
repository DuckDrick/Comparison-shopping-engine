using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Comparison_shopping_engine.Selenium
{
    abstract class AbstractSeleniumScraper
    {
       
        public List<Product> ScrapeWithSelenium(string search)
        {
            var products = new List<Product>();

            var options = new ChromeOptions();
            //options.AddArgument("headless");
            using (var driver = new ChromeDriver(options))
            {
                string next_page = search;
                driver.Navigate().GoToUrl(next_page);

                do
                {
                    var product_list = GetProductList(driver);
                    foreach (var product in product_list)
                    {
                        if (ShouldScrapeIf(product))
                        {
                            var (price, name, productUrl, photoUrl) = GetInfo(product);
                            products.Add(new Product(name, price, productUrl, photoUrl, "None"));
                        }
                    }

                    next_page = NextPage(driver);
                    driver.Navigate().GoToUrl(next_page);
                } while (ShouldStopScraping(next_page));

                foreach (var product in products)
                {
                    driver.Navigate().GoToUrl(product.link);
                    product.group = GetProductGroup(driver);
                }

                driver.Close();
                driver.Quit();
            }

            return products;

        }

        protected abstract string GetProductGroup(ChromeDriver driver);
        protected abstract bool ShouldStopScraping(string next_page);
        protected abstract string NextPage(ChromeDriver driver);
        protected abstract ReadOnlyCollection<IWebElement> GetProductList(ChromeDriver driver);
        protected abstract bool ShouldScrapeIf(IWebElement product);
        protected abstract (string, string, string, string) GetInfo(IWebElement product); //price, name, product url, photo url
    }
}
