using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExam.UITests.Pages
{
    public class AdminMainPage
    {
        public IWebElement userNameText;

        private IWebDriver Driver { get; set; }

        public AdminMainPage(IWebDriver driver)
        {
            Driver = driver;
            userNameText = Driver.FindElement(By.XPath("//div[@class='user']/span"));
        }

        public HotelsPage GoToHotelsPage()
        {
            Driver.Navigate().GoToUrl(Driver.Url + "/hotels");
            return new HotelsPage(Driver);
        }
    }
}
