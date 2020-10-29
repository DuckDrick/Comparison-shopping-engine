using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Comparison_shopping_engine.Scrapers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Comparison_shopping_engine.Selenium
{
    internal abstract class AbstractSeleniumScraper
    {
        private string _scrape;

        private IEnumerable<ChromeDriver> FillWithDrivers(int amount, ChromeOptions o, ChromeDriverService cds,
            int timeout)
        {
            for (var i = 0; i < amount; i++)
            {
                var driver = new ChromeDriver(cds, o);
                yield return driver;
            }
        }

        public void ScrapeWithSelenium(object s)
        {
            var drivers = new List<ChromeDriver>();
            try
            {
                _scrape = (string) s;
                var amount = Values.scraperAmount;

                var options = new ChromeOptions();
                var chromeDriverService = ChromeDriverService.CreateDefaultService();
                chromeDriverService.HideCommandPromptWindow = true;
                options.AddArguments("--window-size=1920,1080", "--no-sandbox", "--headless");
                drivers = FillWithDrivers(amount, options, chromeDriverService, Values.scraperTimeout).ToList();
                try
                {
                    using (var driver = new ChromeDriver(chromeDriverService, options))
                    {
                        //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Values.scraperTimeout);
                        driver.Navigate().GoToUrl(_scrape);


                        var rgx = new Regex("\\/[^.]*\\.");
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
                            var site = rgx.Match(_scrape).Value.Substring(2).Replace(".", ""); // nuoroda.parduotuves.lt
                            do
                            {
                                var products = new List<Product>();
                                try
                                {
                                    var productList = GetProductList(driver);
                                    foreach (var product in productList)
                                        if (ShouldScrapeIf(product))
                                        {
                                            var (price, name, productUrl, photoUrl) = GetInfo(product);
                                            if (!Database.Search(name.Replace("'", "''"), site))
                                                products.Add(new Product(name.Replace("'", "''"), price, productUrl,
                                                    photoUrl,
                                                    "None",
                                                    site)); // + ".lt"
                                        }
                                }
                                catch (NoSuchElementException e)
                                {
                                    Trace.WriteLine(e.ToString());
                                }

                                for (var take = 0;; take++)
                                {
                                    var start = take * amount;
                                    if (products.Count - 1 > start)
                                    {
                                        var count = products.Count - 1 - start > amount
                                            ? amount
                                            : products.Count - 1 - start;
                                        Parallel.ForEach(products.GetRange(start, count), (product, state, index) =>
                                        {
                                            var productDriver = drivers[(int) index];
                                            productDriver.Manage().Timeouts().ImplicitWait =
                                                TimeSpan.FromSeconds(Values.scraperTimeout);
                                            productDriver.Navigate().GoToUrl(product.Link);
                                            productDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);

                                            var tries = 0;
                                            while (tries < 5)
                                                try
                                                {
                                                    (product.Group, product.ImageUrl) =
                                                        GetProductGroupAndMaybePhotoLink(productDriver,
                                                            product.ImageUrl);
                                                    db.AddOrUpdate(site, product.Name, product.Group, product.Link,
                                                        product.ImageUrl, product.Price.Replace("€", "").Trim());
                                                    Product.productList.Add(product);
                                                    break;
                                                }
                                                catch (NoSuchElementException e)
                                                {
                                                    tries++;
                                                    if (tries == 5) Trace.WriteLine(e.ToString());
                                                }

                                            // try
                                            // {
                                            //     using (var driverp = new ChromeDriver(chromeDriverServicep, op))
                                            //     {
                                            //         
                                            //             driverp.Navigate().GoToUrl(product.Link);
                                            //      
                                            //         var tries = 0;
                                            //         while (tries < 5)
                                            //         {
                                            //
                                            //             try
                                            //             {
                                            //                 (product.Group, product.ImageUrl) = GetProductGroupAndMaybePhotoLink(driverp, product.ImageUrl);
                                            //                 db.AddOrUpdate(site, product.Name, product.Group, product.Link,
                                            //                     product.ImageUrl, product.Price.Replace("€", "").Trim());
                                            //                 break;
                                            //             }
                                            //             catch(NoSuchElementException e)
                                            //             {
                                            //                 tries++;
                                            //                 if (tries == 5)
                                            //                 {
                                            //                     Trace.WriteLine(e.ToString());
                                            //                 }
                                            //             }
                                            //         }
                                            //         
                                            //         driverp.Close();
                                            //         driverp.Quit();
                                            //     }
                                            // }
                                            // catch(WebDriverException e)
                                            // {
                                            //     Trace.WriteLine(e.ToString());
                                            // }
                                        });
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }

                                urlBefore = driver.Url;
                                NavigateToNextPage(driver);
                            } while (!ShouldStopScraping(driver, urlBefore));
                        }

                        driver.Close();
                        driver.Quit();
                    }
                }
                catch (WebDriverException e)
                {
                    ScraperController.Finished();
                    Trace.WriteLine(e.ToString());
                }
                catch (Exception e)
                {
                    ScraperController.Finished();
                    Trace.WriteLine(e.ToString());
                }
                finally
                {
                    CloseDriverList(drivers);
                }
            }
            catch (ThreadAbortException)
            {
                Console.WriteLine("Thread aborted");
            }

            ScraperController.Finished();
        }

        private void CloseDriverList(List<ChromeDriver> drivers)
        {
            foreach (var driver in drivers)
            {
                driver.Close();
                driver.Quit();
            }
        }


        protected abstract void NavigateToNextPage(ChromeDriver driver);
        protected abstract bool AnyElements(ChromeDriver driver);
        protected abstract (string, string) GetProductGroupAndMaybePhotoLink(ChromeDriver driver, string productUrl);
        protected abstract bool ShouldStopScraping(ChromeDriver nextPage, string urlBefor);
        protected abstract ReadOnlyCollection<IWebElement> GetProductList(ChromeDriver driver);
        protected abstract bool ShouldScrapeIf(IWebElement product);

        protected abstract (string, string, string, string)
            GetInfo(IWebElement product); //price, name, product url, photo url
    }
}