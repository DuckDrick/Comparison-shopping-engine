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

        private Scraper2 bigboxscraper;
        private Scraper rdescraper;

        private void Form1_Load(object sender, EventArgs e)
        {
            bigboxscraper = new Scraper2(productList);
            rdescraper = new Scraper(productList);
        }

        private void Scrape(object sender, EventArgs e)
        {
            productList.Items.Clear();
            var urlrde = "https://www.rde.lt/search_result/lt/word/" + search.Text.Replace(" ", "+") + "/page/";
            rdescraper.Scrape(urlrde);
            //var oneaUrl = "https://www.1a.lt/paieska/?q=" + search.Text.Replace(" ", "+");
            var bigboxUrl = "https://bigbox.lt/paieska?controller=search&orderby=position&orderway=desc&ssa_submit=&search_query=" + search.Text.Replace(" ", "+");
            bigboxscraper.StartScraping(bigboxUrl);
            
        }
    }


}
