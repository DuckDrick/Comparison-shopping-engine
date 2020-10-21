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
    public partial class ProductInformationForm : Form
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
        public ProductInformationForm()
        {
            InitializeComponent();
        }
        private void CloseWindow(object sender, EventArgs e)
        {
            this.Close();
        }

        public void SetInformation(Product product)
        {
            productName.Text = product.Name;
            productSource.Text = product.Source;
            productPrice.Text = product.Price;
            productGroup.Text = product.Group;
            productLink.Text = product.Link;
            try
            {
                productPicture.Load(product.ImageUrl);
            }
            catch
            {
                Console.WriteLine(product);
            }
        }
    }
}
