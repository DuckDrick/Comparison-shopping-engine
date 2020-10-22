using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Comparison_shopping_engine
{
    public class Product
    {
        public static BindingList<Product> productList;
        public string Name { get; set; }
        public string Link { get; set; }
        public string Price { get; set; }
        public string Group { get; set; }
        public string ImageUrl { get; set; }
        public string Source { get; set; }

        public Product(string name, string price, string link, string imageUrl, string group, string source)
        {
            this.Name = name;
            this.Price = price;
            this.Link = link;
            this.ImageUrl = imageUrl;
            this.Group = group;
            this.Source = source;
        }

        public bool this[Enum[] e]
        {
            get
            {
                if (e.First().GetType() == typeof(MainGroups))
                {
                    return e.Any(group => Group.Contains(group.ToString()));
                }

                return e.Any(source => Source.Equals(source.ToString()));
            }

        }
    }
}