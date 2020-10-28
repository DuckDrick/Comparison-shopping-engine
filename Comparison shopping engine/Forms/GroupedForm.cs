using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Comparison_shopping_engine.Forms
{
    public partial class GroupedForm : Form
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


        private readonly MainGroups _group;
        private List<Product> items = new List<Product>(); 

        public GroupedForm(MainGroups group)
        {
            InitializeComponent();
            this._group = group;
        }

        private void GoBack(object sender, EventArgs e)
        {
            var mainForm = (MainForm) Tag;
            mainForm.StartPosition = FormStartPosition.Manual;
            mainForm.Location = this.Location;
            mainForm.Size = this.Size;
            mainForm.Show();
            this.Close();
        }

        private void GroupedForm_Load(object sender, EventArgs e)
        {
            SmallerGroups smallerGroups = new SmallerGroups();
            var groupsearch = _group + "Group";
            MethodInfo method = typeof(SmallerGroups).GetMethod(groupsearch);
            List<string> smallerGroupList = (List<string>) method.Invoke(smallerGroups, null);
            foreach (var product in Product.productList)
            {
                if (smallerGroups.Check(product.Group, smallerGroupList))
                {
                    string[] row = {product.Name, product.Price, product.Source};
                    productListView.Items.Add(new ListViewItem(row));
                    items.Add(new Product(product.Name, product.Price, null, null, null, product.Source));
                }
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

            var lv = (ListView)sender;
            var row = lv.SelectedItems[0].SubItems;
            var chosenProduct =
                Product.productList.Where(product => product.Name.Equals(row[0].Text) && product.Source.Equals(row[2].Text)).ToList();
            _pif.SetInformation(chosenProduct[0]);
        }
        private void FilterBox_TextChanged(object sender, EventArgs e)
        {
            productListView.Items.Clear();
            foreach (var item in items)
            {
                if (string.IsNullOrEmpty(FilterBox.Text) || FilterBox.Text.ToLower().Split(' ')
                    .All(p => item.Name.ToLower().Contains(p)))
                {
                    string[] row = { item.Name, item.Price, item.Source };
                    productListView.Items.Add(new ListViewItem(row));
                }
            }
        }
    }
}
