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
    public class RunningPaceCalculatorTest
    {
        private static IWebDriver _driver;

        [OneTimeSetUp]
        
        public static void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Url = "https://www.active.com/fitness/calculators/pace";
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(value: 10);
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            IWebElement popUp = _driver.FindElement(By.CssSelector("#page-wrapper > aside > div > header > span"));
            wait.Until(_driver => popUp.Displayed);
            popUp.Click();
        }

        [OneTimeTearDown]
        
        public static void TearDown()
        {
            _driver.Quit();
        }
        
        [TestCase("1", "5", "13", "00","05", "00")]

        public static void TestRunningPace(string hour, string minutes, string distance, string resultHour, string resultMinutes, string resultSeconds)
        {
            RunningPaceCalculatorPage page = new RunningPaceCalculatorPage(_driver);

            page.ResetValues();
            page.SetTimeValues(hour, minutes);
            page.SetDistance(distance);
            page.SetPaceKM();
            page.CheckResult(resultHour, resultMinutes, resultSeconds);

        }


    }
}
