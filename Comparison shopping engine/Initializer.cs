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
        private static Initializer instance = null;
        private static readonly object padlock = new object();

        Initializer()
        {

        }
        public static bool DoneWithDatabase = false;
        public static Initializer Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Initializer();
                    }

                    return instance;
                }
            }
        }

        public static async void GetProductListFromDatabase()
        {
            Product.productList = new BindingList<Product>();
            var count = Enum.GetNames(typeof(ScrapedSites)).Length;
            for (var site = (ScrapedSites)0; site < (ScrapedSites)count; site++)
            {
                var l = await Database.Get("", site.ToString());
                foreach (var ll in l)
                {
                    Product.productList.Add(ll);
                }
                
            }

            DoneWithDatabase = true;
        }
    }
}
