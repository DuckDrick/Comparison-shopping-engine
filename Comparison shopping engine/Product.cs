using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Comparison_shopping_engine
{
    public class Product
    {
        public string name { get; set; }
        public string link { get; set; }
        public string price { get; set; }
        public string group { get; set; }
        public string imageurl { get; set; }
        public Product (string name, string price, string link, string imageurl, string group)
        {
            this.name = name;
            this.price = price;
            this.link = link;
            this.imageurl = imageurl;
            this.group = group;
        }
    }
}
