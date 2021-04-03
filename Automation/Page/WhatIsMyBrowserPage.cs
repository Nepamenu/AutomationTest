using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Page
{
    public class WhatIsMyBrowserPage
    {
        private static IWebDriver _driver;



        private IWebElement _messageAboutBrowser => _driver.FindElement(By.Id("primary-detection"));

        public WhatIsMyBrowserPage(IWebDriver driver)
        {
        }


        public void OpenPage(string webpage)
        {
            if (webpage == "Chrome")
            {
                _driver = new ChromeDriver();
                _driver.Url = "https://developers.whatismybrowser.com/useragents/parse/?analyse-my-user-agent=yes#parse-useragent";
                Assert.AreEqual("Chrome 89 on Windows 10", _messageAboutBrowser.Text, "The text is not equal");
            }

            else if (webpage == "Firefox")
            {
                _driver = new FireFoxDriver();
                _driver.Url = "https://developers.whatismybrowser.com/useragents/parse/?analyse-my-user-agent=yes#parse-useragent";
                Assert.AreEqual("Firefox 87 on Windows 10", _messageAboutBrowser.Text, "The text is not equal");
            }
        }
        /*
                public void CheckResultoForChrome()
                {
                    Assert.AreEqual("Chrome 89 on Windows 10", _messageAboutBrowser.Text, "The text is not equal");
                }

                public void CheckResultoForFirefox()
                {
                    Assert.AreEqual("Firefox 87 on Windows 10", _messageAboutBrowser.Text, "The text is not equal");
                }*/

    }
}
