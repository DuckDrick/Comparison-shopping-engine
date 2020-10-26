using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comparison_shopping_engine.Selenium;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Comparison_shopping_engine.Selenium
{
    class BigboxScraper : AbstractSeleniumScraper
    {
        protected override void NavigateToNextPage(ChromeDriver driver)
        {
            var next = driver.FindElements(By.CssSelector("li#pagination_next_bottom.pagination_next"));
            if (next.Count == 1)
            {
                var url = driver.FindElement(By.CssSelector("li#pagination_next_bottom.pagination_next")).FindElement(By.CssSelector("a"))
                    .GetAttribute("href");
                driver.Navigate().GoToUrl(url);
            }
        }

        protected override bool AnyElements(ChromeDriver driver)
        {
            return driver.FindElements(By.CssSelector("p.alert.alert-warning")).Count == 0;
        }

        protected override (string, string) GetProductGroupAndMaybePhotoLink(ChromeDriver driver, string photoUrl)
        {
            var spanList = driver.FindElement(By.CssSelector("div.breadcrumb.clearfix"))
                .FindElements(By.CssSelector("a"));
            if (spanList.Count > 3)
            {
                return (spanList[2].Text, photoUrl);
            }

            return ("None", photoUrl);
        }

        protected override bool ShouldStopScraping(ChromeDriver nextPage, string urlBefor)
        {
            return nextPage.Url.Equals(urlBefor);
        }

        protected override ReadOnlyCollection<IWebElement> GetProductList(ChromeDriver driver)
        {
            var list = driver.FindElements(By.CssSelector("li.category-item"));
            return list;
        }

        protected override bool ShouldScrapeIf(IWebElement product)
        {
            if (product.FindElements(
                    By.CssSelector(
                        "span.category-item-buttons.button.ajax_add_to_cart_button.disabled.btn.btn_default"))
                .Count == 1)
            {
                return false;
            }

            return true;
        }

        protected override (string, string, string, string) GetInfo(IWebElement product)
        {
            var price = product.FindElement(By.CssSelector("span.price.product-price")).Text;
            var name = product.FindElement(By.CssSelector("a.product-name")).Text;
            var productUrl = product.FindElement(By.CssSelector("a.product-name")).GetAttribute("href");
            var photoUrl = product.FindElement(By.CssSelector("img.replace-2x.img-responsive")).GetAttribute("src"); ;

            return (price, name, productUrl, photoUrl);
        }
    }
}
