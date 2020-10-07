using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        private void Form1_Load(object sender, EventArgs e)
        {
            // _db = new Database();
            PopulateProductList();
            productPicture.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void Scrape(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy)
                backgroundWorker1.CancelAsync();
            while (this.backgroundWorker1.CancellationPending)
            {
                Application.DoEvents();
            }


            productListView.Items.Clear();
            PopulateProductListView();
            backgroundWorker1.RunWorkerAsync(argument: search.Text);
        }



        private void productList_ClickOnItem(object sender, EventArgs e)
        {
            var itemName = productListView.SelectedItems[0].SubItems[0].Text;
            var itemPrice = productListView.SelectedItems[0].SubItems[1].Text;
            foreach (var product in _productList.Where(product => itemName.Equals(product.Name) && itemPrice.Equals(product.Price)))
            {
                productN.Text = product.Name;
                productPicture.Load(product.ImageUrl);
                productGroup.Text = product.Group;
                productLink.Text = product.Link;
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
                string[] row = { product.Name, product.Price, "rde.lt" };
                var item = new ListViewItem(row);
                productListView.Items.Add(item);
            }
            list = await Database.Get(search.Text.Replace(" ", "%"), "bigbox");
            foreach (var product in list)
            {
                string[] row = { product.Name, product.Price, "bigbox.lt" };
                var item = new ListViewItem(row);
                productListView.Items.Add(item);
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bw = sender as BackgroundWorker;
            var paieska = (string)e.Argument;
            new PiguScraper(bw, paieska.Replace(" ", "+")).ScrapeWithSelenium();
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            var l = (List<Product>)e.UserState;
            foreach (var product in l)
            {
                string[] row = { product.Name, product.Price, "Pigu.lt" };
                productListView.Items.Add(new ListViewItem(row));
            }
            _productList.AddRange(l);

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Scraping Done");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy)
            {
                backgroundWorker1.CancelAsync();
            }
        }
    }


}
