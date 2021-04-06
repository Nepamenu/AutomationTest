using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Page
{
    public class HW4_DropDownDemoPage : BasePage
    {
        private const string _pageAddress = "https://www.seleniumeasy.com/test/basic-select-dropdown-demo.html";
        private const string _firstSelectedPrefixText = "First selected option is : ";
        private const string _multiSelectedPrefixText = "Options selected are : ";

        private SelectElement _multiDropDown => new SelectElement(Driver.FindElement(By.Id("multi-select")));
        private IWebElement _firstSelectedButton => Driver.FindElement(By.Id("printMe"));
        private IWebElement _getAllSelected => Driver.FindElement(By.Id("printAll"));
        private IWebElement _multiResultText => Driver.FindElement(By.CssSelector(".getall-selected"));


        public HW4_DropDownDemoPage(IWebDriver webdriver) : base(webdriver)
        {
            Driver.Url = _pageAddress;
        }

        public HW4_DropDownDemoPage SelectFromMultipageDropDown(List<string> statesLites)
        {
            Actions action = new Actions(Driver);
            action.KeyDown(Keys.Control);

            foreach (string state in statesLites)
            {
                foreach (IWebElement option in _multiDropDown.Options)
                {
                    if (state.Equals(option.GetAttribute("value")))
                    {
                        option.Click();
                    }
                }

            }

            action.KeyUp(Keys.Control);
            action.Build().Perform();
            return this;
        }

        public HW4_DropDownDemoPage ClickFirstSelectedButton()
        {
            _firstSelectedButton.Click();
            return this;
        }

        public HW4_DropDownDemoPage ClickGetAllSelectedButton()
        {
            _getAllSelected.Click();
            return this;
        }


        public HW4_DropDownDemoPage VerifyFirstSelectedState(string firstState)
        {
            Assert.AreEqual(_firstSelectedPrefixText + firstState, _multiResultText.Text, "Different first State");
            return this;
        }

        public HW4_DropDownDemoPage VerifyAllSelectedState(List<string> statesLites)
        {
            foreach (string state in statesLites)
            {
                foreach (IWebElement option in _multiDropDown.Options)
                {
                    Assert.AreEqual(_multiSelectedPrefixText + option, _multiResultText.Text, "Different selected States");
                }

            }

            return this;
        }
    }
}
