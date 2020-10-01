using System;
using System.Collections.Generic;
using System.Drawing;
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
        Database db;
        //private Scraper_Novastar scraperNovastar;

        private void Form1_Load(object sender, EventArgs e)
        {
            db = new Database();
            bigboxscraper = new Scraper2(productList, db);
            rdescraper = new Scraper(productList, db);
            PopulateProductList();
            //scraperNovastar = new Scraper_Novastar(productList);
        }

        private void Scrape(object sender, EventArgs e)
        {
            productList.Items.Clear();
            PopulateProductListView();
            rdescraper.Scrape(search.Text.Replace(" ", "+"), ProductList);
            bigboxscraper.StartScraping(search.Text.Replace(" ", "+"), ProductList);
            //scraperNovastar.StartScraping(search.Text.Replace(" ", "%20"));

        }

        private void productList_ClickOnItem(object sender, EventArgs e)
        {
            var itemname = productList.SelectedItems[0].SubItems[0].Text;
            var itemprice = productList.SelectedItems[0].SubItems[1].Text;
            foreach (var product in ProductList)
            {
                if (String.Compare(product.name, itemname) == 0 && String.Compare(product.price, itemprice) == 0)
                {
                    productN.Text = product.name;
                    productPicture.Load(product.imageurl);
                    productGroup.Text = product.group;
                
                    productLink.Text = product.link;
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(productLink.Text);
        }

        private async void PopulateProductList()
        {
            ProductList = await Database.Get("", "rde");
            ProductList.AddRange(await Database.Get("", "bigbox"));
        }

        private async void PopulateProductListView()
        {
            var list = await Database.Get(search.Text.Replace(" ", "%"), "rde");
            foreach (var product in list)
            {
                string[] row = { product.name, product.price‎, "rde.lt" };
                var item = new ListViewItem(row);
                productList.Items.Add(item);
            }
            list = await Database.Get(search.Text.Replace(" ", "%"), "bigbox");
            foreach (var product in list)
            {
                string[] row = { product.name, product.price‎, "bigbox.lt" };
                var item = new ListViewItem(row);
                productList.Items.Add(item);
            }
        }
    }


}
