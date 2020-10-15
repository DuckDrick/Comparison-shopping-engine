using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Comparison_shopping_engine.Selenium
{
    class SkytechScraper : AbstractSeleniumScraper
    {
        public SkytechScraper(BackgroundWorker bw, string scrape) : base(bw, "http://skytech.lt/search.php?keywords=" + scrape + "&x=0&y=0&search_in_description=0&pagesize=500")
        {
        }

        protected override void GroupItems(List<Product> products)
        {
            Parallel.ForEach(products, product =>
            {
                var chromeDriverService = ChromeDriverService.CreateDefaultService();
                chromeDriverService.HideCommandPromptWindow = true;
                var options = new ChromeOptions();
                options.AddArguments("--headless", "--no-sandbox");
                var driver = new ChromeDriver(chromeDriverService, options);
                //var driver = new ChromeDriver();
                driver.Navigate().GoToUrl(product.Link);
                var tries = 0;
                while (tries < 5)
                {
                    try
                    {
                        product.Group = GetProductGroup(driver);
                        break;
                    }
                    catch
                    {
                        tries++;
                    }
                }

                tries = 0;
                while (tries < 5)
                {
                    try
                    {
                        product.ImageUrl = GetProductImage(driver);
                        break;
                    }
                    catch
                    {
                        tries++;
                    }
                }

                driver.Close();
            });
        }

        private string GetProductImage(ChromeDriver driver)
        {
            return driver.FindElement(By.Id("main-product-image")).GetAttribute("src");
        }

        protected override bool AnyElements(ChromeDriver driver)
        {
            if (driver.FindElements(By.ClassName("productListing-info")).Count == 0)
            {
                return true;
            }

            return false;
        }

        protected override string GetProductGroup(ChromeDriver driver)
        {
            var list = driver.FindElement(By.ClassName("navba-breadcrumb"));
            var group = list.FindElements(By.CssSelector("a"));
            foreach (var productgroup in group)
            {
                if (!productgroup.Text.Equals("Pradžia"))
                {
                    return productgroup.Text;
                }
            }

            return "None";
        }

        protected override bool ShouldStopScraping(string nextPage)
        {
            return false;
        }

        protected override string NextPage(ChromeDriver driver)
        {
            return "done";
        }

        protected override ReadOnlyCollection<IWebElement> GetProductList(ChromeDriver driver)
        {
            var list = driver.FindElements(By.CssSelector("tr.productListing"));
            return list;
        }

        protected override bool ShouldScrapeIf(IWebElement product)
        {
            return true;
        }

        protected override (string, string, string, string) GetInfo(IWebElement product)
        {
            string price;
            price = product.FindElement(By.CssSelector("strong")).Text;
            var name = product.FindElement(By.ClassName("name")).Text;
            var productUrl = product.FindElement(By.CssSelector("a")).GetAttribute("href");
            string photoUrl = "";

            return (price, name, productUrl, photoUrl);
        }
    }
}
