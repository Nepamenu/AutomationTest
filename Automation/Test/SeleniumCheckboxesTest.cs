using Automation.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Test
{
    public class SeleniumCheckboxesTest
    {
        private static IWebDriver _driver;
       // private SeleniumCheckboxesPage page;

        [OneTimeSetUp]
        public static void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Url = "https://www.seleniumeasy.com/test/basic-checkbox-demo.html";
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
           // page = new SeleniumCheckboxesPage(_driver); taip nesuveikia


        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            _driver.Quit();
        }

        [Test]

        public static void TestOneCheckbox()
        {
            SeleniumCheckboxesPage page = new SeleniumCheckboxesPage(_driver);
            string result = "Success - Check box is checked";

            page.CheckOneCheckbox();
            page.CheckResult(result);

        }
        [Test]
        public static void TestMultiplyCheckboxes()
        {
            SeleniumCheckboxesPage page = new SeleniumCheckboxesPage(_driver);

            page.UncheckOneCheckbox();
            page.CheckAllCheckboxes();
            page.CheckMultiplyResult();
        }
       
        [Test]

        public static void TestMultiplyCheckboxesIsUnchecked()
        {
            SeleniumCheckboxesPage page = new SeleniumCheckboxesPage(_driver);

            page.UncheckOneCheckbox();
            page.CheckAllCheckboxes();
            page.UncheckAllButton();
            page.CheckMultiplyCheckboxesStatus();

        }


    }
}
