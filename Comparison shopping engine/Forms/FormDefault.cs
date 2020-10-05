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
    public partial class FormDefault : Form
    {
        public FormDefault()
        {
            InitializeComponent();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            (new Form1()).Show(); this.Close();

            // gali buti problemu nes visad reikes is db pasiimti produktus
        }
    }
}
