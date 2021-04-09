using Automation.Drivers;
using Automation.Page;
using Automation.Tools;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Test
{
    public class BaseTest
    {
        protected static IWebDriver driver;
        public static DropdownDemoNewPage _dropDownDemoNewPage;
        public static VartuTechnikaPage _vartuTechnikaPage;
        public static SebCalculatorPage _sebCalculatorPage;
        public static DemoLuminorMainPage _demoLuminorMainPage;
        public static DemoLuminorPaskolaAutoPage _demoLuminorPaskolaAutoPage;


        [OneTimeSetUp]
        public static void Setup()
        {

            driver = CustomDriver.GetChromeDriver();
            // _dropDownDemoNewPage = new DropdownDemoNewPage(driver);
            //  _vartuTechnikaPage = new VartuTechnikaPage(driver);
            _sebCalculatorPage = new SebCalculatorPage(driver);
            _demoLuminorMainPage = new DemoLuminorMainPage(driver);
            _demoLuminorPaskolaAutoPage = new DemoLuminorPaskolaAutoPage(driver);

        }

        [TearDown]
        public static void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                MyScreenshot.TakeScreenshot(driver);
            }
        }

        [OneTimeTearDown]
        public static void OneTimeTearDown()
        {
            driver.Quit();
        }

    }
}
