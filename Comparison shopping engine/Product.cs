using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Comparison_shopping_engine
{
    class Product
    {
        private string name, link;
        private double price;
        public Product (string name, double price, string link)
        {
        this.name=name;
        this.price=price;
        this.link=link;
        }
    }
}
