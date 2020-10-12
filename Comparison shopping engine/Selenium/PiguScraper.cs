using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Comparison_shopping_engine.Selenium
{
    class PiguScraper : AbstractSeleniumScraper
    {
        protected override bool AnyElements(ChromeDriver driver)
        {
            return driver.FindElementsByXPath("//*[@id=\"productListLoader\"]").Count > 0;
        }

        protected override string GetProductGroup(ChromeDriver driver)
        {
            var groups = driver.FindElementByXPath("//*[@id=\"breadCrumbs\"]").FindElements(By.TagName("li"));
            return groups[1].Text.Trim();
        }

        protected override bool ShouldStopScraping(string nextPage)
        {
            var splitLink = nextPage.Split('/');
            return !splitLink[splitLink.Length - 1].Equals("#");
        }

        protected override string NextPage(ChromeDriver driver)
        {
            return driver.FindElementByXPath("//*[@id=\"pagination\"]/div[1]/a[2]").GetAttribute("href");
        }

        protected override ReadOnlyCollection<IWebElement> GetProductList(ChromeDriver driver)
        {
            var products = driver.FindElementByXPath("//*[@id=\"productListLoader\"]").FindElements(By.XPath("//div[contains(@class, \"product-list-item\")]")).Where(product => product.GetAttribute("widget-old") != null).ToList(); ;
            return new ReadOnlyCollection<IWebElement>(products);
        }

        protected override bool ShouldScrapeIf(IWebElement product)
        {
            var spanList = product.FindElement(By.ClassName("product-price")).FindElements(By.TagName("span"));
            return spanList.Count > 1;
        }

        protected override (string, string, string, string) GetInfo(IWebElement product)
        {
            var price = product.FindElement(By.XPath("div/div/div[2]/span[2]")).Text.Replace(" ", "").Replace("€", "") + "€";
            var name = product.FindElement(By.XPath("div/div/a[2]/img")).GetAttribute("alt");
            name = name.Substring(0, name.IndexOf("kaina ir informacija")).Trim();
            var productUrl = product.FindElement(By.XPath("div/div/a[2]")).GetAttribute("href");
            var photoUrl = product.FindElement(By.XPath("div/div/a[2]/img")).GetAttribute("src");

            return (price, name, productUrl, photoUrl);
        }

        protected override void GroupItems(List<Product> products)
        {
            Parallel.ForEach(products, product =>
            {
                var chromeDriverService = ChromeDriverService.CreateDefaultService();
                chromeDriverService.HideCommandPromptWindow = true;
                var options = new ChromeOptions();
                options.AddArguments("--headless", "--no-sandbox", "--disable-gpu", "--incognito", "--proxy-bypass-list=*", "--proxy-server='direct://'", "--log-level=3", "--hide-scrollbars");
                var driver = new ChromeDriver(chromeDriverService, options);
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
                driver.Close();
            }
);
        }

        public PiguScraper(BackgroundWorker bw, string source) : base(bw, "https://pigu.lt/lt/search?q=" + source)
        {
        }
    }
}
