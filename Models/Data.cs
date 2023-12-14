using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Selenium.App.Models
{
    public class Data
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }

        public override string ToString() =>  JsonSerializer.Serialize<Data>(this);
    }
}
