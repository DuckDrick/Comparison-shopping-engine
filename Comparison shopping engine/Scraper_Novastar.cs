using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace Comparison_shopping_engine
{
    class Scraper_Novastar
    {
        private readonly ListView results;
        public Scraper_Novastar (ListView results)
        {
            this.results = results;
        }
        
        
        
        public async Task StartScraping(string url)
        {
            string novastarurl = "https://www.novastar.lt/search/?q=" + url;
            string price = "0";
            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl(novastarurl);
            var titles =
                driver.FindElements(
                    By.XPath("//*[@id=\"react-root\"]/div[2]/div/div[2]/div[2]/div[1]/div[2]/h3/a"));
            foreach (var title in titles)
            {
                string[] row = { "novastar.lt", title.GetAttribute("innerText"), price };
                var item = new ListViewItem(row);
                results.Items.Add(item);
                Console.WriteLine(title.Text);

            }

            var names=driver.FindElements(By.ClassName("link--dark"));
            foreach (var title in names)
            {
                string[] row = { "novastar.lt", title.GetAttribute("innerText"), price };
                var item = new ListViewItem(row);
                results.Items.Add(item);
                Console.WriteLine(title.Text);

            }


        }
    }



}
