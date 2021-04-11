/* 2021-04-12 Jurate B. Automated Testing Final Project
 * Testing Luminor login to account with null ID number */
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Page
{
    public class DemoLuminorInternetoBankasPage : BasePage
    {
        private const string PageAddress = "https://www.luminor.lt/";

        IWebElement _internetoBankasButton => Driver.FindElement(By.CssSelector("#menu > div.menu__mobile-wrapper > ul.menu__list.menu__list--right.clearfix > li:nth-child(1) > a"));
        IWebElement _prisijungimoKodas => Driver.FindElement(By.Id("text"));
        IWebElement _loginbutton => Driver.FindElement(By.Id("loginMsg"));
        IWebElement _errorMessage => Driver.FindElement(By.CssSelector(".infobox error"));


        public DemoLuminorInternetoBankasPage(IWebDriver webdriver) : base(webdriver) { }
        public DemoLuminorInternetoBankasPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
            {
                Driver.Url = PageAddress;
            }
            return this;
        }

        public DemoLuminorInternetoBankasPage ClickInternetoBankasButton()
        {
            _internetoBankasButton.Click();
            return this;
        }
        public DemoLuminorInternetoBankasPage ClearInputField()
        {
            _prisijungimoKodas.Clear();
            return this;
        }

        public DemoLuminorInternetoBankasPage ClickLoginButton()
        {
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
