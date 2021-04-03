using Automation.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Test
{
    public class BasicSeleniumDemoTest
    {
        private static IWebDriver _driver;

        [OneTimeSetUp]
        public static void Setup()
        {
            _driver = new ChromeDriver();

            _driver.Url = "https://www.seleniumeasy.com/test/basic-first-form-demo.html";
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(value: 10); //laukia 10 sekundziu
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(value: 10));
            IWebElement popUp = _driver.FindElement(By.Id(idToFind: "at-cv-lightbox-close"));
            wait.Until(_driver => popUp.Displayed);
            popUp.Click();
        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            _driver.Quit();
        }

        [Test]

        public static void BasicInputField()
        {
            BasicSeleniumDemoPage page = new BasicSeleniumDemoPage(_driver);

            string text = "kaciukai";

            page.InsertTextToInputField(text);
            page.ClickShowMessagaButton();
            page.VerifyResult(text);

        }

        [TestCase("2", "2", "4", TestName = "2 plus 2 eq 4")]
        [TestCase("-5", "3", "-2", TestName = "-5 plus 3 eq -2")]
        [TestCase("a", "b", "NaN", TestName = "a plus b eq NaN")]

        public static void TestSum(string firstInput, string secondInput)
        {
            BasicSeleniumDemoPage page = new BasicSeleniumDemoPage(_driver);
            page.InsertBothValuesToInputFields(firstInput, secondInput);
            page.ClickGetTotalButton();
        }

    }
}
