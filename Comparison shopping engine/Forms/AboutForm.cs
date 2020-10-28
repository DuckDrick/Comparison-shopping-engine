using System;
using System.IO;
using System.Windows.Forms;

namespace Comparison_shopping_engine.Forms
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
            var rtf = File.ReadAllText("../../Resources/Rtfs/About.rtf");
            richTextBox1.Rtf = rtf;
        }

        private void CloseWindow(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
