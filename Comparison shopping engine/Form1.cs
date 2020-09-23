using System;
using System.Windows.Forms;

namespace Comparison_shopping_engine
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Scrape(object sender, EventArgs e)
        {
            results.Clear();
            var urlrde = "https://www.rde.lt/search_result/lt/word/" + search.Text.Replace(" ", "+") + "/page/";
            new Scraper(urlrde, results);
            //var oneaUrl = "https://www.1a.lt/paieska/?q=" + search.Text.Replace(" ", "+");
            var bigboxUrl = "https://bigbox.lt/paieska?controller=search&orderby=position&orderway=desc&ssa_submit=&search_query=" + search.Text.Replace(" ", "+");
            Scraper2 oneaScraper= new Scraper2();
            oneaScraper.startScraping(bigboxUrl, results);
        }
    }


}
