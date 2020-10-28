using Comparison_shopping_engine.Scrapers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Comparison_shopping_engine.Properties;
using ExtensionMethods;

namespace Comparison_shopping_engine.Forms
{
    public partial class SearchForm : Form
    {


        #region WindowMove

        public const int WmNclbuttondown = 0xA1;
        public const int HtCaption = 0x2;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        private void MoveWindow(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WmNclbuttondown, HtCaption, 0);
            }
        }

        #endregion

        private readonly string[] _searchQuery;
        public SearchForm(string searchQuery)
        {
            InitializeComponent();
            this._searchQuery = searchQuery.Split(' ');
        }

        private void ButtonBack_Click(object sender, EventArgs e)
        {
            var mainForm = (MainForm)Tag;
            mainForm.StartPosition = FormStartPosition.Manual;
            mainForm.Location = this.Location;
            mainForm.Size = this.Size;
            mainForm.Show();
            this.Close();

        }
        private bool _expanded1;
        private bool _expanded2;
        private bool _expanded3;
        private void TogglePricePanel(object sender, EventArgs e)
        {
            if (_expanded1)
            {
                pricePanel.AutoSize = false;
                pricePanel.Height = 0;
                pricePanel.Enabled = false;
            }
            else
            {
                pricePanel.AutoSize = true;
                pricePanel.Enabled = true;
            }
            _expanded1 = !_expanded1;
        }

        private void ToggleGroupPanel(object sender, EventArgs e)
        {
            if (_expanded2)
            {
                groupPanel.AutoSize = false;
                groupPanel.Height = 0;
                groupPanel.Enabled = false;
            }
            else
            {
                groupPanel.AutoSize = true;
                groupPanel.Enabled = true;
            }
            _expanded2 = !_expanded2;
        }

        private void ToggleSourcePanel(object sender, EventArgs e)
        {
            if (_expanded3)
            {
                sourcePanel.AutoSize = false;
                sourcePanel.Height = 0;
                sourcePanel.Enabled = false;
            }
            else
            {
                sourcePanel.AutoSize = true;
                sourcePanel.Enabled = true;
            }
            _expanded3 = !_expanded3;
        }

        private void SearchForm_Load(object sender, EventArgs e)
        {
            WaitForProducts();
            LoadListViewItems();
            LoadToCheckedList<MainGroups>(groups);
            //LoadToCheckedGroups(groups);
            LoadToCheckedList<ScrapedSites>(sources);
            SaveListViewItems();
        }

        private void WaitForProducts()
        {
            while (!Initializer.DoneWithDatabase)
            {
                Application.DoEvents();
            }
        }

        private List<Product> _items;
        private void LoadListViewItems()
        {
            searchKeywords.Text = String.Join(" ", _searchQuery);
            _items = Product.productList.Where(product => 
                _searchQuery.All(query => 
                    product.Name.ToLower().Contains(query.ToLower()))).ToList();
            var rows = GetRows(_items);
            productListView.Items.AddRange(rows);
            Product.productList.ListChanged += addToListView;
        }

        private void addToListView(object sender, ListChangedEventArgs e)
        {
            var p = Product.productList[e.NewIndex];
            string[] row = {p.Name, p.Price, p.Source};
            if (productListView.InvokeRequired)
            {
                productListView.Invoke((MethodInvoker)delegate ()
                {
                    ListViewItem item = new ListViewItem(row);
                    productListView.Items.Add(item);
                    productListView.EnsureVisible(productListView.Items.Count - 1);
                });
            }
           
        }

        private void LoadToCheckedList<T>(CheckedListBox clb) where T : Enum
        {
            var values = Enum.GetValues(typeof(T));
            if (values.GetValue(0).GetType()==typeof(MainGroups))
            {
                SmallerGroups smallerGroups = new SmallerGroups();
                foreach (var group in values)
                {
                    var count=0;
                    var groupsearch = group + "Group";
                    MethodInfo method = typeof(SmallerGroups).GetMethod(groupsearch);
                    List<string> smallerGroupList = (List<string>)method.Invoke(smallerGroups, null);
                    foreach (var smallerGroup in smallerGroupList)
                    {
                        foreach (var item in _items)
                        {
                            if (item.Group.Contains(smallerGroup))
                            {
                                count++;
                            }
                        }
                        
                    }
                    clb.Items.Add(new CheckBoxItem(group, count));
                }
            }
            else
            {
                foreach (var value in values)
                {
                    clb.Items.Add(new CheckBoxItem(value, CountHowMany((T)value)));
                }
            }

        }


        private int CountHowMany<T>(T value)
        {
            if (value.GetType() == typeof(MainGroups))
            {
                return _items.Count(product => product.Group.Contains(value.ToString()));
            }

            return _items.Count(product => product.Source.Contains(value.ToString()));

        }

        private void Filter_Click(object sender, EventArgs e)
        {
            productListView.Items.Clear();
            FilterBox.Clear();

            var selectedGroups = groups.CheckedItems.OfType<CheckBoxItem>().Select(item => (MainGroups) item.e);
            var selectedSources = sources.CheckedItems.OfType<CheckBoxItem>().Select(item => (ScrapedSites) item.e);
            var priceFrom = from.Text;
            var priceTo = to.Text;

            var filteredList = FilterListByPrice(priceFrom, priceTo);
            //filteredList = FilterListByChoice(selectedGroups, filteredList);
            filteredList = FilterListByChoice(selectedSources, filteredList);
            filteredList = FilterListBySmallerGroups(filteredList, selectedGroups.ToList());

            var rows = GetRows(filteredList);
            productListView.Items.AddRange(rows);
            SaveListViewItems();
        }

        private ListViewItem[] GetRows(IEnumerable<Product> products)
        {
            return products.Select(product => new ListViewItem(product.getListViewItemRow())).ToArray();
        }
        private List<Product> FilterListByChoice<T>(IEnumerable<T> selection, List<Product> list) where T : Enum
        {
            var enumerable = selection.ToList();
            if (enumerable.Any())
            {
                list = list.Where(product => product[selection.Select(s => (Enum)Enum.Parse(typeof(T), s.ToString())).ToArray()]).ToList();
            }

            return list;
        }

        private List<Product> FilterListBySmallerGroups(List<Product> list, List<MainGroups> groups)
        {
            SmallerGroups smallerGroups = new SmallerGroups();
            foreach (var group in groups)
            {
                var groupsearch = group + "Group";
                MethodInfo method = typeof(SmallerGroups).GetMethod(groupsearch);
                List<string> smallerGroupList = (List<string>)method.Invoke(smallerGroups, null);
                foreach (var product in list.ToArray())
                {
                    if (!smallerGroups.Check(product.Group, smallerGroupList))
                    {
                        list.Remove(product);
                    }

                }
            }
            return list;
        }
        private List<Product> FilterListByPrice(string priceFrom, string priceTo)
        {
            var priceF = priceFrom == "" ? -1f : float.Parse(priceFrom);
            var priceT = priceTo == "" ? 999999f : float.Parse(priceTo);

            return _items.Where(product =>
            {
                var priceString = product.Price.Replace('€', ' ').Trim();
                var pPrice = float.Parse(priceString);
                return priceF <= pPrice && pPrice <= priceT;
            }).ToList();
        }


        private void From_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            if (e.KeyChar == (char) 8) return;
            var textBox = ((TextBox) sender);
            var text = textBox.Text;
            var dotCount = text.Count(c => c == ',');
            if (dotCount != 1) return;
            var dec = text.Split(',')[1].Length;
            if (dec == 2 || e.KeyChar == ',')
            {
                e.Handled = true;
            }
        }

        private ProductInformationForm _pif;
        private void ShowMoreInfoAboutProduct(object sender, EventArgs e)
        {
            if (_pif == null || _pif.IsDisposed)
            {
                _pif = new ProductInformationForm();
                _pif.Show();
            }

            var lv = (ListView) sender;
            var row = lv.SelectedItems[0].SubItems;
            var chosenProduct = (from product in Product.productList
                where product.Name.Equals(row[0].Text) && product.Source.Equals(row[2].Text)
                select product).ToList();
             _pif.SetInformation(chosenProduct[0]);
        }

        private ScraperController scraperController = null;
        private void StartScraping(object sender, EventArgs e)
        {
            if (scraperController == null)
            {
                scraperController = new ScraperController(sources.CheckedItems.OfType<CheckBoxItem>().Select(item=>(ScrapedSites)item.e).ToArray());
                scraperController.Begin(String.Join(" ", _searchQuery));
                scrapingPictureBox.Image= Image.FromFile($"../../Resources/Icons/scrapingloading.gif");
                scrapingPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                scraperController.Kill();
                scrapingPictureBox.Image = null;
                scraperController = null;
            }
        }

        private void scrapingInfo_Click(object sender, EventArgs e)
        {
            Form form = new ScraperInfo();
            form.ShowDialog();
        }

        private void scrapingSettings_Click(object sender, EventArgs e)
        {
            Form form = new ScraperSettings();
            form.ShowDialog();
        }
        private List<Product> items = new List<Product>();
        private void FilterBox_TextChanged(object sender, EventArgs e)
        {
            productListView.Items.Clear();
            foreach (var item in items)
            {
                if (string.IsNullOrEmpty(FilterBox.Text) || item.Name.ToLower().Contains(FilterBox.Text.ToLower())
                                                         || item.Price.ToLower().Contains(FilterBox.Text.ToLower())
                                                         || item.Source.ToLower().Contains(FilterBox.Text.ToLower()))
                {
                    string[] row = { item.Name, item.Price, item.Source };
                    productListView.Items.Add(new ListViewItem(row));
                }
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            FilterBox.Clear();
            productListView.Items.Clear();
            foreach (var item in items)
            {
                string[] row = {item.Name, item.Price, item.Source};
                productListView.Items.Add(new ListViewItem(row));

            }
        }

        private void SaveListViewItems()
        {
            items.Clear();
            foreach (var product in productListView.Items)
            {
                var collumns = ((ListViewItem)product).SubItems;
                items.Add(new Product(collumns[0].ToString().Split('{', '}')[1],
                    collumns[1].ToString().Split('{', '}')[1], null, null, null,
                    collumns[2].ToString().Split('{', '}')[1]));
            }
        }
    }

    public class CheckBoxItem
    {
        public object e { get; set; }
        private int count;

        public CheckBoxItem(object e, int count)
        {
            this.e = e;
            this.count = count;
        }

        public override string ToString()
        {
            return $"{e} ({count})";
        }
    }
}
