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
    public partial class SearchForm : Form
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
        public SearchForm()
        {
            InitializeComponent();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            var mainForm = (MainForm)Tag;
            mainForm.StartPosition = FormStartPosition.Manual;
            mainForm.Location = this.Location;
            mainForm.Size = this.Size;
            mainForm.Show();
            this.Close();

        }
        private bool Expanded1 = false;
        private bool Expanded2 = false;
        private bool Expanded3 = false;
        private void button1_Click(object sender, EventArgs e)
        {
            if (Expanded1)
            {
                pricePanel.AutoSize = false;
                pricePanel.Height = 0;
                pricePanel.Enabled = true;
            }
            else
            {
                pricePanel.AutoSize = true;
                pricePanel.Enabled = true;
            }
            Expanded1 = !Expanded1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Expanded2)
            {
                groupPanel.AutoSize = false;
                groupPanel.Height = 0;
                groupPanel.Enabled = true;
            }
            else
            {
                groupPanel.AutoSize = true;
                groupPanel.Enabled = true;
            }
            Expanded2 = !Expanded2;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Expanded3)
            {
                sourcePanel.AutoSize = false;
                sourcePanel.Height = 0;
                sourcePanel.Enabled = true;
            }
            else
            {
                sourcePanel.AutoSize = true;
                sourcePanel.Enabled = true;
            }
            Expanded3 = !Expanded3;
        }

        private void SearchForm_Load(object sender, EventArgs e)
        {
            LoadToCheckedList<MainGroups>(groups);
            LoadToCheckedList<ScrapedSites>(sources);
        }

        private static void LoadToCheckedList<T>(CheckedListBox clb) where T : System.Enum
        {
            var values = Enum.GetValues(typeof(T));
            foreach (var value in values)
            {
                clb.Items.Add(value);
            }
        }
    }
}
