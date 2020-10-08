using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;

namespace Comparison_shopping_engine.Selenium
{
    abstract class AbstractSeleniumScraper
    {
        private readonly string _scrape;
        private readonly BackgroundWorker _bw;
        
        protected AbstractSeleniumScraper(BackgroundWorker bw, string scrape)
        {
            this._scrape = scrape;
            this._bw = bw;
        }
        public void ScrapeWithSelenium()
        {
            

            //var options = new ChromeOptions();
            //options.AddArgument("headless");
            using (var driver = new ChromeDriver())
            {
                string nextPage = _scrape;
                driver.Navigate().GoToUrl(nextPage);

                driver.Manage().Window.Position = new Point(0, 0);
                driver.Manage().Window.Size = new Size(1920, 1080);
                Regex rgx = new Regex("\\/.*\\.");

                if (AnyElements(driver))
                {
                    var db = new Database();
                    var site = rgx.Match(_scrape).Value.Substring(2).Replace(".", "");
                    do
                    {
                        var products = new List<Product>();
                        var productList = GetProductList(driver);
                        foreach (var product in productList)
                        {
                            if (ShouldScrapeIf(product))
                            {
                                var (price, name, productUrl, photoUrl) = GetInfo(product);
                                if (!Database.Search(name.Replace("'", "''"), site))
                                    products.Add(new Product(name.Replace("'", "''"), price, productUrl, photoUrl, "None",
                                    site + ".lt"));
                            }

                            if (!_bw.CancellationPending) continue;
                            driver.Close();
                            driver.Quit();
                            return;
                        }


                        foreach (var product in products)
                        {
                            driver.Navigate().GoToUrl(product.Link);
                            var tries = 0;
                            while (tries < 5)
                            {
                                try
                                {
                                    product.Group = GetProductGroup(driver);
                                    db.AddOrUpdate(site, product.Name, product.Group, product.Link, product.ImageUrl, product.Price.Replace("€", "").Trim());

                                    break;
                                }
                                catch
                                {
                                    tries++;
                                }
                            }

                            if (!_bw.CancellationPending) continue;
                            driver.Close();
                            driver.Quit();
                            _bw.ReportProgress(1, products.Where(p => !p.Group.Equals("None")).ToList());
                            return;
                        }

                        _bw.ReportProgress(1, products);

                        driver.Navigate().GoToUrl(nextPage);
    
                        nextPage = NextPage(driver);
                        driver.Navigate().GoToUrl(nextPage);
       
                    } while (ShouldStopScraping(nextPage) && !_bw.CancellationPending);

                }

                driver.Close();
                driver.Quit();
            }

        }

        protected abstract bool AnyElements(ChromeDriver driver);
        protected abstract string GetProductGroup(ChromeDriver driver);
        protected abstract bool ShouldStopScraping(string nextPage);
        protected abstract string NextPage(ChromeDriver driver);
        protected abstract ReadOnlyCollection<IWebElement> GetProductList(ChromeDriver driver);
        protected abstract bool ShouldScrapeIf(IWebElement product);
        protected abstract (string, string, string, string) GetInfo(IWebElement product); //price, name, product url, photo url
    }
}
