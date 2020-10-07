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
    class NovastarScraper : AbstractSeleniumScraper
    {
        protected override bool AnyElements(ChromeDriver driver)
        {
            return true;
        }

        protected override string GetProductGroup(ChromeDriver driver)
        {
            throw new NotImplementedException();
        }

        protected override bool ShouldStopScraping(string next_page)
        {
            return false;
        }

        protected override string NextPage(ChromeDriver driver)
        {//*[@id="pagination"]/div[1]/span/a[2]
            //return driver.FindElementByXPath("//*[@id=\"react-root\"]/div[2]/div/div[2]/div[3]/div/a[3]").GetAttribute("href");
            var link = driver.FindElementsByClassName("page-selector");
            if (link.Count == 0)
            {
                return "https://www.novastar.lt/";
            }
            else
            {
                return link[0].GetAttribute("href");
            }
        }

        protected override ReadOnlyCollection<IWebElement> GetProductList(ChromeDriver driver)
        {
            //return driver.FindElements(By.ClassName("product__item"));
            return driver.FindElementsByClassName("product__item");
        }

        protected override bool ShouldScrapeIf(IWebElement product)
        {
            var spanList = product.FindElements(By.ClassName("product__item"));
            return spanList.Count > 0;
        }

        protected override (string, string, string, string) GetInfo(IWebElement product)
        {
            var price = product.FindElement(By.XPath("div[2]/div/div[2]/div[2]/div[1]/div[3]/div[1]/span/span[1]"))
                .Text;
            var name = product.FindElement(By.XPath("div[2]/div/div[2]/div[2]/div[1]/div[2]/h3/a")).Text;
            var productUrl = product.FindElement(By.XPath("div[2]/div/div[2]/div[2]/div[1]/div[2]/h3/a"))
                .GetAttribute("href");
            var photoUrl = "https://www.novastar.lt/" + product.FindElement(By.XPath("div[2]/div/div[2]/div[2]/div[1]/div[1]/div/a[1]/img"))
                .GetAttribute("src");
            return (price, name, productUrl, photoUrl);
        }

        public NovastarScraper(BackgroundWorker bw, string scrape) : base(bw, "https://www.novastar.lt/search/?q=" + scrape)
        {

        }
    }
}
