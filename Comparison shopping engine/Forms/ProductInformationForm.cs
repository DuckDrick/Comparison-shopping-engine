using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Comparison_shopping_engine.Forms
{
    public partial class ProductInformationForm : Form
    {
        public ProductInformationForm()
        {
            InitializeComponent();
        }

        private void CloseWindow(object sender, EventArgs e)
        {
            Close();
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

        private void productLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(productLink.Text);
        }

        #region WindowMove

        public const int WmNclbuttondown = 0xA1;
        public const int HtCaption = 0x2;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        [DllImport("user32.dll")]
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
    }
}