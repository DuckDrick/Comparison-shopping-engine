using System;
using System.Windows.Forms;

namespace Comparison_shopping_engine
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Scrape(object sender, EventArgs e)
        {
            var url = "https://www.rde.lt/search_result/lt/word/" + search.Text.Replace(" ", "+") + "/page/";
            new Scraper(url, results);
        }
    }


}
