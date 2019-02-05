using FinalExam.UITests.Models;
using OpenQA.Selenium;
using Serilog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExam.UITests.Pages
{
    public class AdminLoginPage 
    {
        private IWebElement emailInput;
        private IWebElement passwordInput;
        private IWebElement submit;

        private IWebDriver Driver { get; set; }

        public AdminLoginPage(IWebDriver driver)
        {
            Driver = driver;
            emailInput = Driver.FindElement(By.Name("email"));
            passwordInput = Driver.FindElement(By.Name("password"));
            submit = Driver.FindElement(By.XPath("//*[@type='submit']"));
        }

        public AdminMainPage LogIn()
        {
            var userName = ConfigurationManager.AppSettings["AdminUserEmail"];
            var password = ConfigurationManager.AppSettings["AdminUserPass"];
            emailInput.SendKeys(userName);
            passwordInput.SendKeys(password);
            submit.Click();
            return new AdminMainPage(Driver);
        }
    }
}
