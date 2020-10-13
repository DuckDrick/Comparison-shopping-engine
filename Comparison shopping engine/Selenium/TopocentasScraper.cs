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
    class TopocentasScraper : AbstractSeleniumScraper
    {
        public TopocentasScraper(BackgroundWorker bw, string scrape) : base(bw, "https://topocentras.lt/catalogsearch/result/?q="+scrape)
        {
        }

        protected override void GroupItems(List<Product> products)
        {
            int i=0;
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
                        i++;
                        product.Group = GetProductGroup(driver);
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

        protected override bool AnyElements(ChromeDriver driver)
        {
            if (driver.FindElements(By.ClassName("ProductNotFoundPage-errorHeader-2Xo")).Count == 0)
            {
                return true;
            }

            return false;
        }

        protected override string GetProductGroup(ChromeDriver driver)
        {
            var group = driver.FindElements(By.ClassName("breadcrumbs-breadcrumbLink-2NB"));
            List<String> list;
            foreach (var productgroup in group)
            {
                if (!productgroup.Text.Equals("Topocentras"))
                {
                    return productgroup.Text;
                }
            }

            return "None";
        }

        protected override bool ShouldStopScraping(string nextPage)
        {
            if (nextPage.Equals("done"))
            {
                return false;
            }

            return true;
        }

        protected override string NextPage(ChromeDriver driver)
        {
            if (driver.FindElements(By.CssSelector("a.Pager-nextButton-3UR")).Count == 1)
            {
                return driver.FindElement(By.CssSelector("a.Pager-nextButton-3UR")).GetAttribute("href");
            }

            return "done";
        }

        protected override ReadOnlyCollection<IWebElement> GetProductList(ChromeDriver driver)
        {
            var list = driver.FindElements(By.ClassName("ProductGrid-productWrapper-1hm"));
            return list;
        }

        protected override bool ShouldScrapeIf(IWebElement product)
        {
            return true;
        }

        protected override (string, string, string, string) GetInfo(IWebElement product)
        {
            string price;
            price = product.FindElement(By.ClassName("Price-price-27p")).Text;
            var name = product.FindElement(By.ClassName("ProductGrid-productName-1JN")).Text;
            var productUrl = product.FindElement(By.ClassName("ProductGrid-link-3Q6")).GetAttribute("href");
            string photoUrl ="";
            var tries = 0;
            while (tries < 5)
            {
                try
                {
                    photoUrl = product.FindElement(By.TagName("img")).GetAttribute("src");
                    break;
                }
                catch
                {
                    tries++;
                }
            }

            return (price, name, productUrl, photoUrl);

        }
    }
}
