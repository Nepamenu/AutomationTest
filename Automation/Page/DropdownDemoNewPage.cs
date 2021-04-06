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
    public class DropdownDemoNewPage : BasePage
    {
        private const string _pageAdress = "https://www.seleniumeasy.com/test/basic-select-dropdown-demo.html";

        private const string _defaultText = "Day selected :- ";

        private const string _firstSelectedPrefixText = "First selected option is : ";

        private SelectElement _firstDropDown => new SelectElement(Driver.FindElement(By.Id("select-demo")));

        private SelectElement _multiDropDown => new SelectElement(Driver.FindElement(By.Id("multi-select")));

        private IWebElement _visibleText => Driver.FindElement(By.CssSelector(".selected-value"));
        private IWebElement _firstSelectedButton => Driver.FindElement(By.Id("printMe"));
        private IWebElement _getAllSelectedButton => Driver.FindElement(By.Id("printAll"));
        private IWebElement _multiResultText => Driver.FindElement(By.CssSelector(".getall-selected"));

        public DropdownDemoNewPage(IWebDriver webdriver) : base(webdriver)
        {
            Driver.Url = _pageAdress;

        }

        public DropdownDemoNewPage SelectFromDropdownByValue(DayOfWeek value)
        {
            // _firstDropDown.SelectByText(visibleText);
            _firstDropDown.SelectByValue(value.ToString());
            return this;
        }

        public DropdownDemoNewPage SelectFromDropdownByText(string visibleText)
        {
            _firstDropDown.SelectByText(visibleText);
            return this;
        }

        public DropdownDemoNewPage SelectFromDropdownByText(int index)
        {
            _firstDropDown.SelectByIndex(index);
            return this;
        }



        public DropdownDemoNewPage VerifySelectedValue(DayOfWeek value)
        {
            // Assert.IsTrue(_visibleText.Text.Contains(value));
            Assert.AreEqual(_defaultText + value.ToString(), _visibleText.Text, "Texts are not equal");
            return this;
        }

        public DropdownDemoNewPage SelectFromMultipleDropdorn(List<string> statesList)
        {
            Actions action = new Actions(Driver);
            action.KeyDown(Keys.Control);

            foreach (string state in statesList)
            {
                foreach (IWebElement option in _multiDropDown.Options)
                {
                    if (state.Equals(option.GetAttribute("value")))
                    {
                        option.Click();
                    }
                }
            }


            /* foreach (IWebElement option in _multiDropDown.Options )
             {
                 if (elements.Contains(option.GetAttribute("value")))
                 {
                     option.Click();
                 }
             }*/

            action.KeyUp(Keys.Control);
            action.Build().Perform();


            /*  _multiDropDown.SelectByValue("California");
              Actions action = new Actions(Driver);
              action.KeyDown(Keys.Control);
              _multiDropDown.SelectByValue("Florida");
              action.KeyUp(Keys.Control);
              action.Build().Perform();*/
            return this;
        }

        public DropdownDemoNewPage ClickFirstSelectedButton()
        {
            _firstSelectedButton.Click();
            return this;
        }

        public DropdownDemoNewPage ClickGetAllSelectedButton()
        {
            _getAllSelectedButton.Click();
            return this;
        }

        public DropdownDemoNewPage VerifyFirstSelectedState(string firstState)
        {
            Assert.AreEqual(_firstSelectedPrefixText + firstState, _multiResultText.Text, "Text is wrong");
            return this;
        }

        public DropdownDemoNewPage VerifyAllSelectedState(string firstState)
        {
            Assert.AreEqual(_firstSelectedPrefixText + firstState, _multiResultText.Text, "Text is wrong");
            return this;
        }
    }
}

