﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;

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
            //options.AddArgument("headless");
            using (var driver = new ChromeDriver(options))
            {
                string nextPage = _scrape;
                driver.Navigate().GoToUrl(nextPage);
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
                                if (!Database.Search(name, site))
                                    products.Add(new Product(name, price, productUrl, photoUrl, "None",
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
                            product.Group = GetProductGroup(driver);
                            db.AddOrUpdate(site, product.Name, product.Group, product.Link, product.ImageUrl, product.Price.Replace("€", "").Trim());
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
