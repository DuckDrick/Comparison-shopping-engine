﻿using System;
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
    class ErmitazasScaper : AbstractSeleniumScraper
    {
        public ErmitazasScaper(BackgroundWorker bw, string scrape) : base(bw, "https://ermitazas.lt/index.php?lang=2&cl=search&searchparam="+scrape+"&_artperpage=90")
        {
        }

        protected override void NavigateToNextPage(ChromeDriver driver)
        {
            if (driver.FindElements(By.CssSelector("a.next.ml-2.padding-4-8-2")).Count > 0)
            {
                var newurl = driver.FindElement(By.CssSelector("a.next.ml-2.padding-4-8-2")).GetAttribute("href");
                driver.Navigate().GoToUrl(newurl);
            }
        }

        protected override bool AnyElements(ChromeDriver driver)
        {
            if (driver.FindElements(By.CssSelector("div.alert.alert-warning.text-center")).Count == 0)
            {
                return false;
            }

            return true;
        }

        protected override (string, string) GetProductGroupAndMaybePhotoLink(ChromeDriver driver, string imageUrl)
        {
            var group = driver.FindElement(By.CssSelector("li.active.end")).Text;
            //imageUrl = driver.FindElement(By.TagName("a")).GetAttribute("href");
            return (group, imageUrl);
        }

        protected override bool ShouldStopScraping(ChromeDriver nextPage, string urlBefor)
        {
            if (urlBefor.Equals(nextPage.Url))
            {
                return true;
            }
            return false;
        }

        protected override ReadOnlyCollection<IWebElement> GetProductList(ChromeDriver driver)
        {
            var list = driver.FindElements(By.ClassName("media-item"));
            return list;
        }

        protected override bool ShouldScrapeIf(IWebElement product)
        {
            return true; // scrapinti jeigu buvo rasta itemai kurie neispirkti
        }

        protected override (string, string, string, string) GetInfo(IWebElement product)
        {
            string price;
            if (product.FindElements(By.CssSelector("span.price.orange")).Count==0)
            {
                price = product.FindElement(By.CssSelector("span.price.grey")).Text;
            }
            else
            {
                price = product.FindElement(By.CssSelector("span.price.orange")).Text;
            }
            var name = product.FindElement(By.CssSelector("span.media-title.lh17.inline-block.hover-underline")).Text;
            var productUrl = product.FindElement(By.CssSelector("a")).GetAttribute("href");
            string photoUrl = product.FindElement(By.CssSelector("img.minh300.maxh255.center-img.lazy")).GetAttribute("src");
            return (price, name, productUrl, photoUrl);
        }
    }
}
