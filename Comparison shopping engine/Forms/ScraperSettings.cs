using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Comparison_shopping_engine.Forms
{
    public partial class ScraperSettings : Form
    {
        public ScraperSettings()
        {
            InitializeComponent();
        }

        private void ScraperSettings_Load(object sender, EventArgs e)
        {
            scraperAmount.Value = Values.scraperAmount;
            scraperTimeout.Value = Values.scraperTimeout;
        }

        private void scraperSettingsSave_Click(object sender, EventArgs e)
        {
            Values.scraperAmount = (int) scraperAmount.Value;
            Values.scraperTimeout = (int) scraperTimeout.Value;
            Close();
        }

        private void scraperSettingsCancel_Click(object sender, EventArgs e)
        {
            Close();
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