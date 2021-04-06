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
    public class HW4_DropDownDemoTest
    {
        private static HW4_DropDownDemoPage _page;
        [OneTimeSetUp]

        public static void Setup()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _page = new HW4_DropDownDemoPage(driver);
        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            // _page.CloseBrowser();
        }

        [TestCase("Texas", "Florida", TestName = "First selected Texas")]
        [TestCase("California", "Pennsylvania", "Ohio", TestName = "First selected California")]
        
        public static void MultiplyDropDownFirstSelectedTest(params string[] states)
        {
            _page.SelectFromMultipageDropDown(states.ToList())
                .ClickFirstSelectedButton()
                .VerifyFirstSelectedState(states[0]);
        }

        [TestCase("California", "Washington", TestName = "Selected states California, Washington")]
        [TestCase("New Jersey", "California", "Washington", "Texas", TestName = "Selected states New Jersey, California, Washington, Texas")]

        public static void MultiplyDropDownAllSelectedTest(params string[] states)
        {
            _page.SelectFromMultipageDropDown(states.ToList())
                .ClickGetAllSelectedButton()
                .VerifyAllSelectedState(states.ToList());
        }

    }
}
