/* 2021-04-12 Jurate B. Automated Testing Final Project
 * Testing Luminor login to account with null value ID number */
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Automation.Page
{
    public class DemoLuminorInternetoBankasPage : BasePage
    {
        private const string PageAddress = "https://ib.dnb.lt/";

        IWebElement _prisijungimoKodas => Driver.FindElement(By.Id("text"));
        IWebElement _loginbutton => Driver.FindElement(By.Id("logout"));
        //IWebElement _errorMessage => Driver.FindElement(By.CssSelector(".infobox error"));
        IWebElement _errorMessage => Driver.FindElement(By.CssSelector("#wrap > div > div.infobox.error > label"));


        public DemoLuminorInternetoBankasPage(IWebDriver webdriver) : base(webdriver) { }
        public DemoLuminorInternetoBankasPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
            {
                Driver.Url = PageAddress;
            }
            return this;
        }

       
        public DemoLuminorInternetoBankasPage ClearInputField()
        {
            _prisijungimoKodas.Clear();
            return this;
        }

        public DemoLuminorInternetoBankasPage ClickLoginButton()
        {
            Thread.Sleep(10000);
            _loginbutton.Click();
            return this;
        }

        public DemoLuminorInternetoBankasPage VerifyErrorMessage()
        {
            Assert.IsTrue(_errorMessage.Text.Contains("Neteisingi prisijungimo parametrai"), "Different error messages");
            return this;
        }
    }
}
