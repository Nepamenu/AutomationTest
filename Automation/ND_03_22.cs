using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Automation
{
    public class ND_03_22
    {

        private static IWebDriver _chrome;

        [OneTimeSetUp]
        public static void SetUp()
        {
            _chrome = new ChromeDriver();
            _chrome.Url = "https://www.seleniumeasy.com/test/basic-first-form-demo.html";
            _chrome.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(value: 10); //laukia 10 sekundziu
            WebDriverWait wait = new WebDriverWait(_chrome, TimeSpan.FromSeconds(value: 10));

            IWebElement popUp = _chrome.FindElement(By.Id(idToFind: "at-cv-lightbox-close"));
            wait.Until(_chrome => popUp.Displayed);
            popUp.Click();
        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            _chrome.Quit();
        }

        [TestCase("2", "2", "4", TestName = "2 plus 2 eq 4")]
        [TestCase("-5", "3", "-2", TestName = "-5 plus 3 eq -2")]
        [TestCase("a", "b", "NaN", TestName = "a plus b eq NaN")]

        public static void TestTwoPlusTwo( string firstInput, string secondInput, string result)
        {
                    
                       
            _chrome.FindElement(By.Id("sum1")).SendKeys(firstInput);
            _chrome.FindElement(By.Id("sum2")).SendKeys(secondInput);
            _chrome.FindElement(By.CssSelector("#gettotal > button")).Click();
            Assert.AreEqual(result, _chrome.FindElement(By.Id("displayvalue")).Text, "Result is NOK");
            _chrome.FindElement(By.Id("sum1")).Clear();
            _chrome.FindElement(By.Id("sum2")).Clear();

        }
        /*
        [Test]

        public static void TestMinusFivePlusThree()
        {
            
            _chrome.FindElement(By.Id("sum1")).SendKeys("-5");
            _chrome.FindElement(By.Id("sum2")).SendKeys("3");
            _chrome.FindElement(By.CssSelector("#gettotal > button")).Click();
            Assert.AreEqual("-2", _chrome.FindElement(By.Id("displayvalue")).Text, "-5 + 3 is not equal -2");
            
        }

        [Test]

        public static void TestAPlusB()
        {
            
            _chrome.FindElement(By.Id("sum1")).SendKeys("a");
            _chrome.FindElement(By.Id("sum2")).SendKeys("b");
            _chrome.FindElement(By.CssSelector("#gettotal > button")).Click();
            Assert.AreEqual("NaN", _chrome.FindElement(By.Id("displayvalue")).Text, "input values are NotANumber");
           
        }*/
              
      

    }
}
