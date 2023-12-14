using Microsoft.VisualBasic.FileIO;
using OfficeOpenXml;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Selenium.App.Models;
using Selenium.App.Models.POMs;
using Selenium.App.Servises;
using System.Collections.Generic;

namespace Selenium.App
{
    public class Program
    {
        static void Main(string[] args)
        {

            using (IWebDriver driver = new ChromeDriver())
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial; 
                Demoblaze page = new(driver);
                page.NavigateTo();

                page.Phones.Click();
                Thread.Sleep(2000);
                var Phones = page.Products;
                var Products =new List<Product>();
                foreach (var phone in Phones)
                {
                    var name = phone.FindElement(By.XPath(".//div[@class='card-block']//h4")).Text;
                    var link = phone.FindElement(By.XPath(".//a")).GetAttribute("href").ToString();
                    var price = phone.FindElement(By.XPath(".//div[@class='card-block']//h5")).Text;
                    var article = phone.FindElement(By.XPath(".//div[@class='card-block']//p")).Text;
                    Products.Add(new Product(name,article,price,link));
                }
                driver.Quit();
                var file = @"C:\Users\muc01_uipath-st04\source\rpa\training\Selenium.App\Selenium.App\MyWorkbook.xlsx";
                SeleniumServices.DeleteIfExist(file);
                using (var package = new ExcelPackage(new FileInfo(file)))
                {
                    var ws = package.Workbook.Worksheets.Add("Products");

                    var range = ws.Cells["A1"].LoadFromCollection(Products, true);
                    ws.Cells["A1:C3"].AutoFitColumns();
                    package.Save();

                }

            }

        }


        /********************************************************************************************/
    }
}

/*
driver.Navigate().GoToUrl("https://formy-project.herokuapp.com/form");

var list = new SelectElement(driver.FindElement(By.Id("select-menu"))).SelectedOption.Text;
foreach (var item in list)
{
    Console.WriteLine(item);
}*/

/* using(var package = new ExcelPackage(file) )
   {
       Console.WriteLine("hi --> 1");
       var ws = package.Workbook.Worksheets[0];
       var row = 2;
       while (string.IsNullOrWhiteSpace(ws.Cells[row,1].Value?.ToString()) == false )
       {
           list.Add(ws.Cells[row,1].Value.ToString());
           row++;
       }
   }*/

//var dataService = new JasonFileDataService();
//var data = dataService.GetData();
//try
//{
//    IWebElement div = driver.FindElement(By.ClassName("dbsFrd"));
//    IWebElement button = driver.FindElement(By.Id("W0wltc"));
//    button.Click();
//}
//catch (Exception ex) { Console.WriteLine(ex.Message); }

//    IWebElement element = driver.FindElement(By.Name("q"));
//element.SendKeys(data.Where(d => d.Id == 2).FirstOrDefault<Data>().Name);




//Thread.Sleep(1000);
//driver.Quit();

//var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
//wait.Until(d => File.Exists(file));