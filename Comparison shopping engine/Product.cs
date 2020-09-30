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
    class Product
    {
        public string name { get; set; }
        public string link { get; set; }
        public double price { get; set; }
        public Product (string name, double price, string link)
        {
        this.name=name;
        this.price=price;
        this.link=link;
        }
    }
}
