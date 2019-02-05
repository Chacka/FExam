using FinalExam.UITests.Models;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Serilog;
using System;
using System.Configuration;
using System.Linq;
using FinalExam.UITests.Pages;

namespace FinalExam.UITests
{
    [TestFixture]
    public class TestFixture
    {
        protected IWebDriver Driver { get; set; }
        protected WebDriverWait Wait { get; set; }
        private string UserName { get; set; }
        private string Password { get; set; }

        private Random random = new Random();

        public string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private string AppUrl = ConfigurationManager.AppSettings["UiBaseUrl"];

        [OneTimeSetUp]
        public void BeforeAllTests()
        {
            Driver = new ChromeDriver();
            Log.Information($"Chrome Driver instance created");

            Driver.Manage().Window.Maximize();
            Log.Information("Window maximized");

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
        }

        [OneTimeTearDown]
        public void AfterAllTests()
        {
            Driver.Quit();
            TestContext.WriteLine("Browser window closed");
        }

        public AdminMainPage LoginAsAdmin()
        {
            Log.Information("Going to admin login page");
            
            Driver.Navigate().GoToUrl(AppUrl + "/admin");
            Log.Information("Login as admin");
            return new AdminLoginPage(Driver).LogIn();
        }

        public void LoginAsSupplier()
        {
            Driver.Navigate().GoToUrl(AppUrl + "/supplier");
        }

        public void LoginAsRegular()
        {
            Driver.Navigate().GoToUrl(AppUrl + "/login");
        }
    }
}

