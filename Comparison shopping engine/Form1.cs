using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Comparison_shopping_engine.Selenium;

namespace Comparison_shopping_engine
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private List<Product> _productList = new List<Product>();
        // private Database _db;
        //private Scraper_Novastar scraperNovastar;

        private void Form1_Load(object sender, EventArgs e)
        {
            // _db = new Database();
            PopulateProductList();
        }

        private void Scrape(object sender, EventArgs e)
        {
            if(backgroundWorker1.IsBusy)
               backgroundWorker1.CancelAsync();
            productListView.Items.Clear();
            PopulateProductListView();
            backgroundWorker1.RunWorkerAsync();
            

        }



        private void productList_ClickOnItem(object sender, EventArgs e)
        {
            var itemName = productListView.SelectedItems[0].SubItems[0].Text;
            var itemPrice = productListView.SelectedItems[0].SubItems[1].Text;
            foreach (var product in _productList.Where(product => itemName.Equals(product.name) && itemPrice.Equals(product.price)))
            {
                productN.Text = product.name;
                productPicture.Load(product.imageurl);
                productGroup.Text = product.group;
                productLink.Text = product.link;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(productLink.Text);
        }

        private async void PopulateProductList()
        {
            _productList = await Database.Get("", "rde");
            _productList.AddRange(await Database.Get("", "bigbox"));
        }

        private async void PopulateProductListView()
        {
            var list = await Database.Get(search.Text.Replace(" ", "%"), "rde");
            foreach (var product in list)
            {
                string[] row = { product.name, product.price, "rde.lt" };
                var item = new ListViewItem(row);
                productListView.Items.Add(item);
            }
            list = await Database.Get(search.Text.Replace(" ", "%"), "bigbox");
            foreach (var product in list)
            {
                string[] row = { product.name, product.price, "bigbox.lt" };
                var item = new ListViewItem(row);
                productListView.Items.Add(item);
            }
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            var sarasas = new PiguScraper().ScrapeWithSelenium("https://pigu.lt/lt/search?q=kompiuteris+msi+intel+7");
            e.Result = sarasas;
            if (backgroundWorker1.CancellationPending)
            {
                //CANCEL
                e.Cancel = true;
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            List<Product> pL = (List<Product>) e.Result;
            foreach (var product in pL)
            {
                string[] row = {product.name, product.price, "Pigu.lt"};
                productListView.Items.Add(new ListViewItem(row));
            }
            
        }
    }


}
