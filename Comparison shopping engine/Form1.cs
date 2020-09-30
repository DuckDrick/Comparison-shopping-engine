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
        private LinkLabel productLink = new LinkLabel();
        //private Scraper_Novastar scraperNovastar;

        private void Form1_Load(object sender, EventArgs e)
        {
            bigboxscraper = new Scraper2(productList);
            rdescraper = new Scraper(productList);
            //scraperNovastar = new Scraper_Novastar(productList);
            productLink.Location = new Point(760, 310);
            this.Controls.Add(productLink);
            productLink.Size = new System.Drawing.Size(900, 26);
            productLink.Font = new Font("Arial", 8, FontStyle.Regular);
        }

        private void Scrape(object sender, EventArgs e)
        {
            productList.Items.Clear();
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
                    productLink.Text = product.link;
                }
            }
        }
    }


}
