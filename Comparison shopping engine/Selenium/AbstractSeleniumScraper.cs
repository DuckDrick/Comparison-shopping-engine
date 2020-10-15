using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

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

            var options = new ChromeOptions();
            var chromeDriverService = ChromeDriverService.CreateDefaultService();
            //chromeDriverService.HideCommandPromptWindow = true;
            options.AddArguments("--window-size=1920,1080");//, "--headless");
            try
            {
                using (var driver = new ChromeDriver(chromeDriverService, options))
                {
                    driver.Navigate().GoToUrl(_scrape);

                    Regex rgx = new Regex("\\/[^.]*\\.");
                    string urlBefore;
                    bool any;
                    try
                    {
                        any = AnyElements(driver);
                    }
                    catch (NoSuchElementException e)
                    {
                        Trace.WriteLine(e.ToString());
                        any = false;
                    }

                    if (any)
                    {
                        var db = new Database();
                        var site = rgx.Match(_scrape).Value.Substring(2).Replace(".", "");
                        do
                        {

                          
                            var products = new List<Product>();
                            try
                            {
                                var productList = GetProductList(driver);
                                foreach (var product in productList)
                                {
                                    if (ShouldScrapeIf(product))
                                    {
                                        var (price, name, productUrl, photoUrl) = GetInfo(product);
                                        if (!Database.Search(name.Replace("'", "''"), site))
                                            products.Add(new Product(name.Replace("'", "''"), price, productUrl,
                                                photoUrl,
                                                "None",
                                                site + ".lt"));
                                    }

                                    if (!_bw.CancellationPending) continue;
                                    driver.Close();
                                    driver.Quit();
                                    return;
                                }
                            }
                            catch (NoSuchElementException e)
                            {
                                Trace.WriteLine(e.ToString());

                            }

                            for (var take = 0;; take++)
                            {
                                var start = take * 2;
                                if (products.Count - 1 > start && !_bw.CancellationPending)
                                {
                                    var count = products.Count - 1 - start > 2 ? 2 : products.Count - 1 - start;

                                    Parallel.ForEach(products.GetRange(start, count), (product) =>
                                    {
                                        var chromeDriverServicep = ChromeDriverService.CreateDefaultService();
                                        //chromeDriverServicep.HideCommandPromptWindow = true;
                                        var op = new ChromeOptions();
                                        op.AddArguments("--window-size=1920,1080");//, "--headless");
                                        try
                                        {
                                            using (var driverp = new ChromeDriver(chromeDriverServicep, op))
                                            {
                                                driverp.Navigate().GoToUrl(product.Link);
                                                var tries = 0;
                                                while (tries < 5)
                                                {

                                                    try
                                                    {
                                                        product.Group = GetProductGroup(driverp);
                                                        db.AddOrUpdate(site, product.Name, product.Group, product.Link,
                                                            product.ImageUrl, product.Price.Replace("€", "").Trim());


                                                        break;
                                                    }
                                                    catch(NoSuchElementException e)
                                                    {
                                                        tries++;
                                                        if (tries == 5)
                                                        {
                                                            Trace.WriteLine(e.ToString());
                                                        }
                                                    }
                                                }

                                                driverp.Quit();
                                            }
                                        }
                                        catch(WebDriverException e)
                                        {
                                            Trace.WriteLine(e.ToString());
                                        }

                                    });
                                }
                                else
                                {
                                    break;
                                }
                            }

                            _bw.ReportProgress(1, products.Where(e => !e.Group.Equals("None")).ToList());

                            urlBefore = driver.Url;
                            NavigateToNextPage(driver);



                        } while (!ShouldStopScraping(driver, urlBefore) && !_bw.CancellationPending);

                    }

                    driver.Close();
                    driver.Quit();
                }
            }
            catch (WebDriverException e)
            {
                Trace.WriteLine(e.ToString());
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.ToString());
            }

        }


        protected abstract void NavigateToNextPage(ChromeDriver driver);
        protected abstract bool AnyElements(ChromeDriver driver);
        protected abstract string GetProductGroup(ChromeDriver driver);
        protected abstract bool ShouldStopScraping(ChromeDriver nextPage, string urlBefor);
        protected abstract ReadOnlyCollection<IWebElement> GetProductList(ChromeDriver driver);
        protected abstract bool ShouldScrapeIf(IWebElement product);
        protected abstract (string, string, string, string) GetInfo(IWebElement product); //price, name, product url, photo url
    }
}
