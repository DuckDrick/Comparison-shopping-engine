using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Comparison_shopping_engine;

namespace Comparison_shopping_engine
{
    public class Product : IEquatable<Product>, IComparable<Product>
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

        public bool Equals(Product product)
        {
            return product.Group == this.Group && product.Name == this.Name;
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

        public int CompareTo(Product other)
        {
            return float.Parse(this.Price).CompareTo(float.Parse(other.Price));
        }
        
        public static bool operator > (Product p1, Product p2)
        {
            return p1.CompareTo(p2) == 1;
        }

        public static bool operator < (Product p1, Product p2)
        {
            return p1.CompareTo(p2) == -1;
        }

        public static bool operator >= (Product p1, Product p2)
        {
            return p1.CompareTo(p2) >= 0;
        }

        public static bool operator <= (Product p1, Product p2)
        {
            return p1.CompareTo(p2) <= 0;
        }
        
    }
}


namespace ExtensionMethods
{
    public static class MyExtensions
    {
        public static string[] getListViewItemRow(this Product product)
        {
            return new[] {product.Name, product.Price, product.Source};
        }
    }
}