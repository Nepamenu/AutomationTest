using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Page
{
   public class DemoLuminorMainPage : BasePage
    {
        private const string PageAddress = "https://www.luminor.lt/";

        private IWebElement _phoneIcon => Driver.FindElement(By.CssSelector("#menu > div.menu__mobile-wrapper > ul.menu__list.menu__list--right.clearfix > li:nth-child(3) > a"));
        private IWebElement _contact => Driver.FindElement(By.LinkText("Kontaktai"));
        private IWebElement _resultContact => Driver.FindElement(By.CssSelector("body > div.l-wrap > div.l-content > div.content-block > div:nth-child(1) > div:nth-child(1) > p:nth-child(1) > a > b"));
        public DemoLuminorMainPage(IWebDriver webdriver) : base(webdriver) { }

        public DemoLuminorMainPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
            {
                Driver.Url = PageAddress;
            }
            return this;
        }

        public DemoLuminorMainPage ClickPhoneIcon()
        {
            _phoneIcon.Click();
            return this;
        }

        public DemoLuminorMainPage ClickKontaktaiLink()
        {
            _contact.Click();
            return this;
        }

        public DemoLuminorMainPage VerifyContactPhoneNr()
        {
            string contactPhoneNumber = "Konsultacijos tel. +370 5 239 3444";
            Assert.AreEqual(contactPhoneNumber, _resultContact.Text, "Contacts are wrong");
            return this;
        }
    }
}
