using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comparison_shopping_engine
{
    sealed class Initializer
    {
        public static bool DoneWithDatabase = false;
        
        public static async void GetProductListFromDatabase()
        {
            Product.productList = new BindingList<Product>();
            var count = Enum.GetNames(typeof(ScrapedSites)).Length;
            for (var site = (ScrapedSites)0; site < (ScrapedSites)count; site++)
            {
                var l = await Database.Get(site.ToString());
                foreach (var ll in l)
                {
                    Product.productList.Add(ll);
                }
                
            }

            DoneWithDatabase = true;
        }
    }
}
