using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Comparison_shopping_engine.Forms
{
    public partial class GroupedForm : Form
    {

        #region WindowMove

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        private void MoveWindow(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        #endregion

        private MainGroups group;
    
        public GroupedForm(MainGroups group)
        {
            InitializeComponent();
            this.group = group;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            // this.DialogResult = System.Windows.Forms.DialogResult.OK;
            var mainForm = (MainForm) Tag;
            mainForm.StartPosition = FormStartPosition.Manual;
            mainForm.Location = this.Location;
            mainForm.Size = this.Size;
            mainForm.Show();
            this.Close();

            // gali buti problemu nes visad reikes is db pasiimti produktus
        }

        private void GroupedForm_Load(object sender, EventArgs e)
        {
            foreach (var product in Product.productList.Where(product => product.Group.Contains(group.ToString())).ToList())
            {
                string[] row = {product.Name, product.Price, product.Source};
                productListView.Items.Add(new ListViewItem(row));
            }
            
        }

    }
}
