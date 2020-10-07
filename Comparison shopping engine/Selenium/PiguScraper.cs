using System.Collections.ObjectModel;
using System.ComponentModel;
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
            return driver.FindElementByXPath("//*[@id=\"productListLoader\"]")
                .FindElements(By.ClassName("product-list-item"));
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
            var productUrl = product.FindElement(By.XPath("div/div/a[2]")).GetAttribute("href");
            var photoUrl = product.FindElement(By.XPath("div/div/a[2]/img")).GetAttribute("src");

            return (price, name, productUrl, photoUrl);
        }

        public PiguScraper(BackgroundWorker bw, string source) : base(bw, "https://pigu.lt/lt/search?q=" + source)
        {
        }
    }
}
