using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExam.UITests.Pages
{
    public class HotelsPage
    {
        private IWebDriver Driver { get; set; }

        private IWebElement AddButton { get; set; }

        private IWebElement TableElement { get; set; }



        public HotelsPage(IWebDriver driver)
        {
            Driver = driver;
            AddButton = Driver.FindElement(By.XPath("//button[contains(text(),'Add')]"));
        }


    }
}
