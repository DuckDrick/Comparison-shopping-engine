using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace Comparison_shopping_engine.Selenium
{
    class NovastarScraper : AbstractSeleniumScraper
    {
        protected override void NavigateToNextPage(ChromeDriver driver)
        {
            var m = driver.FindElementsByClassName("list-pagination");
            if (m.Count != 0)
            {
                var pages = m[0].FindElements(By.TagName("a"));
                var n = pages[pages.Count - 1];
               
                ((IJavaScriptExecutor)driver)
                    .ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
                Actions action = new Actions(driver);
                action.MoveToElement(n);
                var ad = driver.FindElementByXPath("//*[@id=\"soundest-forms-container\"]")
                    .FindElements(By.TagName("div")).Count;
                if (ad > 80)
                {
                    driver.FindElementByClassName("soundest-form-background-image-close").Click();
                }
                action.Click().Build().Perform();
                Thread.Sleep(3000);
            }
        }

        protected override bool AnyElements(ChromeDriver driver)
        {
            return true; //Kodėl įhardcodintas true?
        }

        protected override (string, string) GetProductGroupAndMaybePhotoLink(ChromeDriver driver, string productUrl)
        {
            Thread.Sleep(1500);
            var group = driver.FindElement(By.ClassName("breadcrumbs"));
            var g = group.FindElements(By.TagName("span"));
            var kk = g[1].Text;
            return (kk, productUrl);
        }

        protected override bool ShouldStopScraping(ChromeDriver chromeDriver, string urlBefore)
        {

            Thread.Sleep(1000);
            if (chromeDriver.Url.Equals(urlBefore))
            {
                return true;
            }
            return false;

        }


        protected override ReadOnlyCollection<IWebElement> GetProductList(ChromeDriver driver)
        {
            ReadOnlyCollection<IWebElement> list;
            //Thread.Sleep(3000);
            try
            {
                list = driver.FindElements(By.ClassName("product__item"));
            }
            catch
            {
                return null;
            }

            if (list != null)
            {
                return list;
            }
            else
            {
                return driver.FindElements(By.ClassName("product__item-mobile"));
            }
            
        }

        protected override bool ShouldScrapeIf(IWebElement product)
        {
            return true; //Vėl true?
        }

        protected override (string, string, string, string) GetInfo(IWebElement product)
        {
            string price;
            if (product.FindElements(By.ClassName("price__standard")).Count != 0)
            {
                price = product.FindElement(By.ClassName("price__standard")).Text;
            }
            else
            {
                price = product.FindElement(By.ClassName("price__value")).Text;
            }
            var name = product.FindElement(By.ClassName("link--dark")).Text;
            var productUrl = product.FindElement(By.ClassName("link--dark")).GetAttribute("href");
            var photoUrl = product.FindElement(By.TagName("img"))
                .GetAttribute("src");
            return (price, name, productUrl, photoUrl);
        }

        public NovastarScraper(BackgroundWorker bw, string scrape) : base(bw, "https://novastar.lt/search/?q=" + scrape)
        {
        }

        public NovastarScraper() : base()
        {

        }

    }
}
