using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Comparison_shopping_engine.Selenium;

namespace Comparison_shopping_engine.Scrapers
{
    class ScraperController
    {
        private List<KeyValuePair<ScrapedSites, Thread>> scrapers;
        public ScraperController(ScrapedSites[] sources)
        {
            CreateSelectedScrapers(sources.Select(g => g.ToString()).ToArray());
        }

        private void CreateSelectedScrapers(string[] sources)
        {
            scrapers = new List<KeyValuePair<ScrapedSites, Thread>>();
            if (sources.Length == 0)
            {
                sources = Enum.GetNames(typeof(ScrapedSites)).Where(name => name != "rde" && name != "bigbox").ToArray();
            }
            foreach(var source in sources)
            {
                var className = source.First().ToString().ToUpper() + source.Substring(1) + "Scraper";
                var scraper = Type.GetType("Comparison_shopping_engine.Selenium." + className);
                var instance = (AbstractSeleniumScraper)Activator.CreateInstance(scraper);
                var thread = new Thread(instance.ScrapeWithSelenium);
                scrapers.Add(new KeyValuePair<ScrapedSites, Thread>((ScrapedSites) Enum.Parse(typeof(ScrapedSites), source), thread));
            }
        }

        public void Begin(string query)
        {
            foreach (var scraper in scrapers)
            {
                var url = Values.Urls[(int) scraper.Key];

                scraper.Value.Start(new object[] {
                    url + query.Replace(" ", "+")
                });
            }
        }

        public void Kill()
        {
            foreach (var scraper in scrapers)
            {
                scraper.Value.Abort();
            }
        }
    }
}
