using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
            var group = driver.FindElement(By.ClassName("breadcrumbs")).Text;
            return group;
        }

        protected override bool ShouldStopScraping(string next_page)
        {
            if (next_page.Equals("https://www.novastar.lt/"))
            {
                return false;
            }
            return false;
        }

        protected override string NextPage(ChromeDriver driver)
        {//*[@id="pagination"]/div[1]/span/a[2]
            //return driver.FindElementByXPath("//*[@id=\"react-root\"]/div[2]/div/div[2]/div[3]/div/a[3]").GetAttribute("href");
            /*var link = driver.FindElementsByClassName("page-selector");
            if (link.Count == 0)
            {
                return "https://www.novastar.lt/";
            }
            else
            {
                return link[0].GetAttribute("href");
            }*/
            /*if (driver.FindElementsByClassName("page_selector selected").Count == 1)
            {
                string url = driver.Url;
                return url.Replace(getcurrentpage(driver), getcurrentpage(driver) + 1);
                //return "https://www.novastar.lt/search/?page=" + getcurrentpage(driver) +1+"&q="
            }
            else
            {
                return "https://www.novastar.lt/";
            }*/
            return "https://www.novastar.lt/";
        }

        protected override ReadOnlyCollection<IWebElement> GetProductList(ChromeDriver driver)
        {
            var list= driver.FindElements(By.ClassName("product__item"));
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
            //var spanList = product.FindElements(By.ClassName("product__item-mobile"));
            //return spanList.Count > 0;
            return true;
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
            var photoUrl = "https://www.novastar.lt/" + product.FindElement(By.ClassName("product__image_wrapper"))
                .GetAttribute("src");
            return (price, name, productUrl, photoUrl);
        }

        public NovastarScraper(BackgroundWorker bw, string scrape) : base(bw, "https://www.novastar.lt/search/?q=" + scrape)
        {

        }

        private string getcurrentpage(ChromeDriver driver)
        {
            return driver.FindElement(By.ClassName("page-selector selected number")).Text;
        }
    }
}
