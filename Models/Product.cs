using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.App.Models
{
    public class Product
    {
        public string Name { get; set; } = string.Empty;
        public string Price { get; set; } = string.Empty;
        public string Link { get; set; } = string.Empty;
        public string Article { get; set; } = string.Empty;

        public Product (string name, string article, string price, string link)
        {
            Name = name;
            Article = article;
            Price = price;
            Link = link;
        }
    }
}
