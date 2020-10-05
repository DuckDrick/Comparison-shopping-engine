using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Comparison_shopping_engine.Forms;
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
            PopulateProductCategory();
            this.productCategory.AutoScroll = true;

        }

        private void Scrape(object sender, EventArgs e)
        {
            if(backgroundWorker1.IsBusy)
               backgroundWorker1.CancelAsync();
            productListView.Items.Clear();
            PopulateProductListView();
            backgroundWorker1.RunWorkerAsync(argument: search.Text);
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
            var paieska = (string) e.Argument;
            var sarasas = new PiguScraper().ScrapeWithSelenium("https://pigu.lt/lt/search?q=" + paieska.Replace(" ", "+"));
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

        private void buttonGaming_Click(object sender, EventArgs e)
        {
            //filtruojam duombaze su žodžiais susijusais su kategorija žaidimai
            /*Form forma= new FormDefault();
            this.Hide();
            forma.ShowDialog(this);
            forma.StartPosition = FormStartPosition.Manual;
            forma.Location = new Point(this.DesktopLocation.X, this.DesktopLocation.Y);*/
        }

        private void buttonTelecomunication_Click(object sender, EventArgs e)
        {
            //filtruojam duombaze su žodžiais susijusais su kategorija telefonai
        }

        private void buttonComputers_Click(object sender, EventArgs e)
        {
            //filtruojam duombaze su žodžiais susijusais su kategorija kompiuteriai
        }
        private void PopulateProductCategory()
        {
            //reiks is duombazes patraukti kategorijas musu padarytas ir is ju padaryti mygtukus
            for (int i = 0; i < 10; i++)
            {
                Button button = new Button();
                button.Height = 100;
                button.Width = 200;
                button.Dock = DockStyle.Bottom;
                button.Text = "test" + i;
                button.ForeColor = System.Drawing.Color.White;
                button.BackColor = System.Drawing.Color.MediumOrchid;
                button.Font = new Font("Centuary Gothic", 12, FontStyle.Bold);
                this.productCategory.Controls.Add(button);
            }

        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST)
                m.Result = (IntPtr)(HT_CAPTION);
        }

        private const int WM_NCHITTEST = 0x84;
        private const int HT_CLIENT = 0x1;
        private const int HT_CAPTION = 0x2;
    }



}
