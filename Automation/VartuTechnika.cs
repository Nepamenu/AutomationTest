using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation
{
    public class VartuTechnika
    {
        private static IWebDriver _driver;

        [OneTimeSetUp]
        public static void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Url = "http://vartutechnika.lt/";
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.FindElement(By.Id("cookiescript_accept")).Click();
            
        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            _driver.Quit();
        }

        [TestCase("2000", "2000", true, false, "665.98€", TestName = "2000 x 2000 + Vartų automatika = 665,98€")]
        [TestCase("4000", "2000", true, true, "1006.43", TestName = "4000 x 2000 + Vartų automatika + Vartų montavimo darbai = 1006.43€")]
        [TestCase("4000", "2000", false, false, "692.35", TestName = "4000 x 2000 = 692.35€")]
        [TestCase("5000", "2000", false, true, "989.21", TestName = "5000 x 2000 + Vartų montavimo darbai = 989.21€")]
        public static void TestVartuTechnika(string width, string height, bool auto, bool works, string result)
        {
            IWebElement widthInputField = _driver.FindElement(By.Id("doors_width"));
            widthInputField.Clear();
            widthInputField.SendKeys(width);
            IWebElement heightInputField = _driver.FindElement(By.Id("doors_height"));
            heightInputField.Clear();
            heightInputField.SendKeys(height);

            IWebElement autoCheckbox = _driver.FindElement(By.Id("automatika"));
            if (auto != autoCheckbox.Selected)
            {
                autoCheckbox.Click();
            }

            IWebElement worksCheckbox = _driver.FindElement(By.Id("darbai"));
            if (works != worksCheckbox.Selected)
            {
                worksCheckbox.Click();
            }
            _driver.FindElement(By.Id("calc_submit")).Click();
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            IWebElement resultBox = _driver.FindElement(By.CssSelector(".col-md-12.alert.alert-success"));
            wait.Until(_driver => resultBox.Displayed);
            //IWebElement resultBox = _driver.FindElement(By.CssSelector("#calc_result > div"));
            Assert.IsTrue(resultBox.Text.Contains(result), $"Failed, expected result was {result}, but actual result was {resultBox.Text}");
           // Assert.AreEqual(result, resultBox.Text, "Are not equal");
        }

    }
}
