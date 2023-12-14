using Selenium.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Selenium.App.Servises
{
    public class JasonFileDataService
    {
        private  string path = "C:/Users/muc01_uipath-st04/source/rpa/training/Selenium.App/Selenium.App/Data/DB.json";

        public IEnumerable<Data> GetData()
        {
            using(var jsonFileReader = File.OpenText(path))
            {
                return JsonSerializer.Deserialize<Data[]>(jsonFileReader.ReadToEnd());
            }
            
        }
    }
}
