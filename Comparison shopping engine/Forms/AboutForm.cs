using System;
using System.Windows.Forms;

namespace Comparison_shopping_engine.Forms
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
            richTextBox1.LoadFile("../../Resources/Rtfs/About.rtf");
        }

        private void CloseWindow(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
