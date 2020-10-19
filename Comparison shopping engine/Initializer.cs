using System;
using System.Collections.Generic;
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

        public void Init()
        {
            GetProductListFromDatabase();
        }

        private async void GetProductListFromDatabase()
        {
            Product.productList = new List<Product>();
            var count = Enum.GetNames(typeof(ScrapedSites)).Length;
            for (var site = ScrapedSites.rde; site < (ScrapedSites) count; site++)
            {
                Product.productList.AddRange(await Database.Get("", site.ToString()));
            }
        }
    }
}
