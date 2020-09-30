using System;
using System.Collections.Generic;
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
        List<Product> ProductList = new List<Product>();
        //private Scraper_Novastar scraperNovastar;

        private void Form1_Load(object sender, EventArgs e)
        {
            bigboxscraper = new Scraper2(productList);
            rdescraper = new Scraper(productList);
            //scraperNovastar = new Scraper_Novastar(productList);
        }

        private void Scrape(object sender, EventArgs e)
        {
            productList.Items.Clear();
            rdescraper.Scrape(search.Text.Replace(" ", "+"));
            bigboxscraper.StartScraping(search.Text.Replace(" ", "+"), ProductList);
            //scraperNovastar.StartScraping(search.Text.Replace(" ", "%20"));

        }

        private void productList_ClickOnItem(object sender, EventArgs e)
        {
            var item = productList.SelectedItems[0].SubItems[0].Text;
            //kazkas.Text = item.SubItems[0].Text;
            productLabel.Text = item;
        }
    }


}
