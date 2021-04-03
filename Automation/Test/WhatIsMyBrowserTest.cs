using Automation.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Test
{
    class WhatIsMyBrowserTest
    {
        private static IWebDriver _driver;

       /* [OneTimeTearDown]
        public static void TearDown()
        {
            _driver.Quit();
        }*/

        [TestCase("Chrome")]
        [TestCase("Firefox")]

        public static void TestWhatIsMyBrowser(string webpage)
        {
            WhatIsMyBrowserPage page = new WhatIsMyBrowserPage(_driver);
            page.OpenPage(webpage);
        }

    }
}
