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
    public class DropdownDemoNewTest
    {
        private static DropdownDemoNewPage _page;
        private static string states;

        [OneTimeSetUp]
        public static void Setup()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            // page = new SeleniumCheckboxesPage(_driver); taip nesuveikia
            _page = new DropdownDemoNewPage(driver);


        }

        [OneTimeTearDown]
        public static void TearDown()
        {
           // _page.CloseBrowser();
        }

        [TestCase (DayOfWeek.Friday, TestName = "Testing simple dropdown with Friday option")]

        public static void SimmpleDropdownTest(DayOfWeek dayOfWeek )
        {
            _page.SelectFromDropdownByValue(dayOfWeek)
                .VerifySelectedValue(dayOfWeek);
        }

        [TestCase ("Ohio", "Florida", "California", TestName = "First selected Ohio")]
        [TestCase("California", "Florida", "California", TestName = "First selected California")]
        [TestCase("Washington","New Jersey", TestName = "HomeWork Nr. 1 with two states, first Washington")] //Test failed, first was New Jersey
        [TestCase("New Jersey", "Washington" , TestName = "HomeWork Nr. 1 with two states, first Washington")] //


        public  static void MultiplyDropDownFirstSelectedTest(params string[] states)

        {
            // List<string> elements = new List<string> { "Ohio", "Florida", "California" };
            //List<string> state = states.Split(',').ToList();

            _page.SelectFromMultipleDropdorn(states.ToList())
                .ClickFirstSelectedButton()
                .VerifyFirstSelectedState(states[0]);

        }

        
        public static void MultiplyDropDownAllSelectedTest()
        {
            List<string> elements = new List<string> { "California", "Ohio", "Florida" };
            _page.SelectFromMultipleDropdorn(elements)
                .ClickGetAllSelectedButton()
                .VerifyFirstSelectedState(elements[0]);

        }



    }
}
