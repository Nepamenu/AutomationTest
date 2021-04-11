/* 2021-04-12 Jurate B. Automated Testing Final Project
 * Testing Luminor Search output with null input value */
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Page
{
    public class DemoLuminoPaieskaPage : BasePage
    {
        private const string PageAddress = "https://www.luminor.lt/lt/paieska";
        private const string textToFind = "";
        private const string result = "Prašome ką nors įvesti.";


        private IWebElement _inputSearch => Driver.FindElement(By.Id("edit-keys-2"));
        private IWebElement _searchButton => Driver.FindElement(By.Id("edit-submit-2"));
        private IWebElement _resultMessage => Driver.FindElement(By.CssSelector(".input__error-message"));


        public DemoLuminoPaieskaPage(IWebDriver webdriver) : base(webdriver) { }
        public DemoLuminoPaieskaPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
            {
                Driver.Url = PageAddress;
            }
            return this;
        }

        public DemoLuminoPaieskaPage ClearInputField()
        {
            _inputSearch.Click();
            return this;
        }

        public DemoLuminoPaieskaPage WriteTextToFind()
        {
            _inputSearch.SendKeys(textToFind);
            return this;
        }

        public DemoLuminoPaieskaPage ClickSearchButton()
        {
            _searchButton.Click();
            return this;
        }

        public DemoLuminoPaieskaPage VerfifyErrorMessage()
        {
            Assert.IsTrue(_resultMessage.Text.Contains(result), "Error message are not the same");
            return this;
        }
    }
}
