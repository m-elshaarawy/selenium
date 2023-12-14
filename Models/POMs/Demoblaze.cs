using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Selenium.App.Models.POMs
{
    public class Demoblaze
    {
        private readonly IWebDriver Driver;

        private const string PageUrl = "https://www.demoblaze.com/";

        public Demoblaze(IWebDriver driver)
        {
            this.Driver = driver;
        }

        public IWebElement Phones => Driver.FindElement(By.XPath("//div[@class='list-group']//a[.='Phones']"));
        public ReadOnlyCollection<IWebElement> Products => Driver.FindElements(By.XPath("//div[@id='tbodyid']/div/div"));
        
        public void NavigateTo()
        {
            Driver.Navigate().GoToUrl(PageUrl);
            //Driver.Manage().Window.Maximize();

        }
    }
}
