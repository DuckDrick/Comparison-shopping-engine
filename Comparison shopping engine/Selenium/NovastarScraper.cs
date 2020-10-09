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
            var group = driver.FindElement(By.ClassName("breadcrumbs"));
            var g = group.FindElements(By.TagName("span"));
            var kk = g[1].Text;
            return kk;
        }

        protected override bool ShouldStopScraping(string next_page)
        {
            /*if (next_page.Equals("https://www.novastar.lt/"))
            {
                return false;
            }*/
            return false;
        }

        protected override string NextPage(ChromeDriver driver)
        {
            /*var link = driver.FindElements(By.CssSelector("a.page-selector.selected")).Count;
            if ((driver.FindElements(By.CssSelector("a.page-selector.selected")).Count == 1)||(driver.FindElements(By.CssSelector("a.page-selector.selected")).Count == 2 && Convert.ToInt32(getcurrentpage(driver)) == 1))
            {
                string url = driver.Url;
                if (Convert.ToInt32(getcurrentpage(driver)) == 1)
                {
                    return "https://www.novastar.lt/search/?page=2&q=xbox%20one";
                }
                else
                {
                    return "https://www.novastar.lt/search/?page="+(Convert.ToInt32(getcurrentpage(driver)) +1)+"&q=xbox%20one";
                }
            }
            else
            {
                return "https://www.novastar.lt/";
            }*/
            return "https://www.novastar.lt/";
        }

        protected override ReadOnlyCollection<IWebElement> GetProductList(ChromeDriver driver)
        {
            //driver.FindElement(By.CssSelector("i.icon.icon--caret")).Click();
            //driver.FindElement(By.CssSelector("div.dropdown-menu__item")).Click();
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
            var photoUrl = product.FindElement(By.TagName("img"))
                .GetAttribute("src");
            return (price, name, productUrl, photoUrl);
        }

        public NovastarScraper(BackgroundWorker bw, string scrape) : base(bw, "https://novastar.lt/search/?q=" + scrape)
        {
        }

        private string getcurrentpage(ChromeDriver driver)
        {
            return driver.FindElement(By.CssSelector("a.page-selector.number")).Text;
        }

        protected override void GroupItems(List<Product> products)
        {
            Parallel.ForEach(products, product =>
            {
                var options = new ChromeOptions();
                options.AddArgument("headless");
                var driver = new ChromeDriver(options);
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
    }
}
