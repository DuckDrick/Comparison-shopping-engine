﻿using System;
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
    public partial class FaqForm : Form
    {
        public FaqForm()
        {
            InitializeComponent();
            richTextBox1.LoadFile("../../Resources/FAQ.rtf");
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
