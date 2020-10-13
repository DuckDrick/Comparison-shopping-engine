using System;
using System.Collections.Generic;

using System.ComponentModel;

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
        private List<Product> _productList2 = new List<Product>();
        // private Database _db;

        private void Form1_Load(object sender, EventArgs e)
        {
            // _db = new Database();
            PopulateProductList();

            productPicture.SizeMode = PictureBoxSizeMode.StretchImage;

            PopulateProductCategory();
            this.productCategory.AutoScroll = true;

        }

        private void Scrape(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(search.Text))
            {
                if (backgroundWorker1.IsBusy)
                    backgroundWorker1.CancelAsync();
                while (this.backgroundWorker1.CancellationPending)
                {
                    Application.DoEvents();
                }

                if (backgroundWorker2.IsBusy)
                    backgroundWorker2.CancelAsync();
                while (this.backgroundWorker2.CancellationPending)
                {
                    Application.DoEvents();
                }
                
                if (backgroundWorker3.IsBusy)
                    backgroundWorker3.CancelAsync();
                while (this.backgroundWorker3.CancellationPending)
                {
                    Application.DoEvents();
                }
                if (backgroundWorker4.IsBusy)
                    backgroundWorker4.CancelAsync();
                while (this.backgroundWorker3.CancellationPending)
                {
                    Application.DoEvents();
                }
                if (backgroundWorker5.IsBusy)
                    backgroundWorker5.CancelAsync();
                while (this.backgroundWorker5.CancellationPending)
                {
                    Application.DoEvents();
                }


                productListView.Items.Clear();
                PopulateProductListView();
                //backgroundWorker1.RunWorkerAsync(argument: search.Text);
                //backgroundWorker2.RunWorkerAsync(argument: search.Text);
                //backgroundWorker3.RunWorkerAsync(argument: search.Text);
                //backgroundWorker4.RunWorkerAsync(argument: search.Text);
                backgroundWorker5.RunWorkerAsync(argument: search.Text);
            }
            else
            {
                MessageBox.Show("Paieškos laukas tuščias");
            }

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
            _productList.AddRange(await Database.Get("", "pigu"));
            _productList.AddRange(await Database.Get("", "novastar"));
            _productList.AddRange(await Database.Get("", "topocentras"));
            _productList.AddRange(await Database.Get("", "skytech"));
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
            list = await Database.Get(search.Text.Replace(" ", "%"), "pigu");
            foreach (var product in list)
            {
                string[] row = { product.Name, product.Price, "pigu.lt" };
                var item = new ListViewItem(row);
                productListView.Items.Add(item);
            }
            list = await Database.Get(search.Text.Replace(" ", "%"), "novastar");
            foreach (var product in list)
            {
                string[] row = { product.Name, product.Price, "novastar.lt" };
                var item = new ListViewItem(row);
                productListView.Items.Add(item);
            }
            list = await Database.Get(search.Text.Replace(" ", "%"), "topocentras");
            foreach (var product in list)
            {
                string[] row = { product.Name, product.Price, "topocentras.lt" };
                var item = new ListViewItem(row);
                productListView.Items.Add(item);
            }
            list = await Database.Get(search.Text.Replace(" ", "%"), "skytech");
            foreach (var product in list)
            {
                string[] row = { product.Name, product.Price, "skytech.lt" };
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
            MessageBox.Show("Pigu scraping done");
        }
        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Novastar scraping done");
        }
        private void backgroundWorker3_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Senuku scraping done");
        }
        private void backgroundWorker4_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Topocentras scraping done");
        }
        private void backgroundWorker5_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Skytech scraping done");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy)
            {
                backgroundWorker1.CancelAsync();
            }
            if (backgroundWorker2.IsBusy)
            {
                backgroundWorker2.CancelAsync();
            }
            if (backgroundWorker3.IsBusy)
            {
                backgroundWorker3.CancelAsync();
            }
            if (backgroundWorker4.IsBusy)
            {
                backgroundWorker4.CancelAsync();
            }
            if (backgroundWorker5.IsBusy)
            {
                backgroundWorker5.CancelAsync();
            }
        }

        private void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bw = sender as BackgroundWorker;
            var paieska = (string)e.Argument;
            new SenukaiScraper(bw, paieska.Replace(" ", "+")).ScrapeWithSelenium();
        }

        private void backgroundWorker3_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            var l = (List<Product>)e.UserState;
            foreach (var product in l)
            {
                string[] row = { product.Name, product.Price, "Senukai.lt" };
                productListView.Items.Add(new ListViewItem(row));
            }
            _productList.AddRange(l);

        }
        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bw = sender as BackgroundWorker;
            var paieska = (string)e.Argument;
            new NovastarScraper(bw, paieska.Replace(" ", "%20")).ScrapeWithSelenium();
        }

        private void backgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            var l = (List<Product>)e.UserState;
            foreach (var product in l)
            {
                string[] row = { product.Name, product.Price, "Novastar.lt" };
                productListView.Items.Add(new ListViewItem(row));
            }
            _productList.AddRange(l);

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

        private void backgroundWorker4_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bw = sender as BackgroundWorker;
            var paieska = (string)e.Argument;
            new TopocentasScraper(bw, paieska.Replace(" ", "%20")).ScrapeWithSelenium();
        }

        private void backgroundWorker4_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            var l = (List<Product>)e.UserState;
            foreach (var product in l)
            {
                string[] row = { product.Name, product.Price, "topocentras.lt" };
                productListView.Items.Add(new ListViewItem(row));
            }
            _productList.AddRange(l);

        }
        private void backgroundWorker5_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bw = sender as BackgroundWorker;
            var paieska = (string)e.Argument;
            new SkytechScraper(bw, paieska.Replace(" ", "+")).ScrapeWithSelenium();
        }

        private void backgroundWorker5_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            var l = (List<Product>)e.UserState;
            foreach (var product in l)
            {
                string[] row = { product.Name, product.Price, "Skytech.lt" };
                productListView.Items.Add(new ListViewItem(row));
            }
            _productList.AddRange(l);

        }
    }



}
