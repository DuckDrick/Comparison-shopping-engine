using System.Collections.ObjectModel;
using System.ComponentModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Comparison_shopping_engine.Selenium
{
    class SenukaiScraper : AbstractSeleniumScraper
    {
        protected override bool AnyElements(ChromeDriver driver)
        {
            return driver.FindElementsByXPath("//*[@id=\"catalog-taxons-products-container\"]").Count > 0;
        }

        protected override (string, string, string, string) GetInfo(IWebElement product) //galimai beda
        {
            var price = product.FindElement(By.XPath("div[3]/div[3]/div/div[2]/div[3]/div[5]/div/div[1]/div[2]/div[1]/div/span/span[1]")).Text.Replace(" ", "").Replace("€", "") + "€"; //xz kaip su replace
            var name = product.FindElement(By.XPath("div[3]/div[3]/div/div[2]/div[3]/div[5]/div/div[1]/div[2]/a[2]")).GetAttribute("alt");
            var productUrl = product.FindElement(By.XPath("div[3]/div[3]/div/div[2]/div[3]/div[5]/div/div[1]/div[2]/a[3]")).GetAttribute("href");
            var photoUrl = product.FindElement(By.XPath("div[3]/div[3]/div/div[2]/div[3]/div[5]/div/div[1]/div[2]/a[1]/img")).GetAttribute("src");

            return (price, name, productUrl, photoUrl);
        }
        protected override string GetProductGroup(ChromeDriver driver)
        {
            var groups = driver.FindElementByXPath("//*[@id=\"page-path-v2\"]").FindElements(By.TagName("li"));  //tf is li
            return groups[1].Text.Trim();
        }

        protected override ReadOnlyCollection<IWebElement> GetProductList(ChromeDriver driver) //galimai beda
        {
            return driver.FindElementByXPath("//*[@id=\"cart-popup-container\"]")
                .FindElements(By.ClassName("catalog-taxons-product"));
        }

        protected override string NextPage(ChromeDriver driver)
        {
            return driver.FindElementByXPath("//*[@id=\"next\"]/div[1]/a[2]").GetAttribute("href"); //tf is div[1]/a[2] //tf is href
        }

        protected override bool ShouldScrapeIf(IWebElement product)
        {
            var spanList = product.FindElement(By.ClassName("catalog-taxons-product-price__item-price")).FindElements(By.TagName("span"));
            return spanList.Count > 1;
        }

        protected override bool ShouldStopScraping(string nextPage)
        {
            var splitLink = nextPage.Split('/');
            return !splitLink[splitLink.Length - 1].Equals("#");
        }

        public SenukaiScraper(BackgroundWorker bw, string source) : base(bw, "https://www.senukai.lt/paieska/?q=" + source)
        {
        }
    }
}
