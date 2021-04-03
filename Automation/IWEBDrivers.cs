using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Automation
{
    public class PuslapioTestavimas
    {
        
        [Test]
        public static void TestYahoopage()
        {
            IWebDriver chrome = new ChromeDriver();
            chrome.Url = "https://login.yahoo.com";
            // chrome.Close();
            IWebElement loginInputField = chrome.FindElement(By.Id("login-username"));
            loginInputField.SendKeys("Test");

        }

        [Test]
        public static void TestSeleniumPage()
        {
            IWebDriver chrome = new ChromeDriver();
            chrome.Url = "https://www.seleniumeasy.com/test/basic-first-form-demo.html";
            IWebElement InputField = chrome.FindElement(By.Id("user-message"));
            Thread.Sleep(5000);
            IWebElement popUp = chrome.FindElement(By.Id("at-cv-lightbox-close"));
            if (popUp.Displayed)
            { popUp.Click(); }

            string myText = "Labas";
            InputField.SendKeys(myText);
            IWebElement button = chrome.FindElement(By.CssSelector("#get-input > button"));
            button.Click();
            IWebElement result = chrome.FindElement(By.Id("display"));

            Assert.AreEqual(myText, result.Text, "Tekstas neatsirado");
            //chrome.quit();
        }

    }
}
