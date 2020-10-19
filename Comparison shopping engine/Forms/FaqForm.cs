using System;
using System.Windows.Forms;

namespace Comparison_shopping_engine.Forms
{
    public partial class FaqForm : Form
    {
        public FaqForm()
        {
            InitializeComponent();
            richTextBox1.LoadFile("../../Resources/Rtfs/FAQ.rtf");
        }

        private void CloseWindow(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
