using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Page
{
    public class SeleniumCheckboxesPage : BasePage
    {
        private IWebElement _oneCheckbox => Driver.FindElement(By.Id("isAgeSelected"));

        private IWebElement _result1 => Driver.FindElement(By.Id("txtAge"));

        private IWebElement _MultiplyCheckboxButton => Driver.FindElement(By.Id("check1"));


        IReadOnlyCollection<IWebElement> _checkboxCollection => Driver.FindElements(By.CssSelector(cssSelectorToFind: ".cb1-element"));



        public SeleniumCheckboxesPage(IWebDriver webdriver) : base(webdriver) { } //constructor + BasePage.cs constructor

        public void CheckOneCheckbox()
        {
            if (!_oneCheckbox.Selected)
            {
                _oneCheckbox.Click();
            }
        }

        public void CheckResult(string result)
        {
            Assert.AreEqual(result, _result1.Text, "Result NOK");
        }

        public void UncheckOneCheckbox()
        {
            if (_oneCheckbox.Selected)
            {
                _oneCheckbox.Click();
            }
        }

        public void CheckAllCheckboxes()
        {
            foreach (IWebElement checkbox in _checkboxCollection)
            {
                if (!checkbox.Selected)
                {
                    checkbox.Click();
                }
            }
        }


        public void CheckMultiplyResult()
        {
            Assert.IsTrue(("Uncheck All").Equals(_MultiplyCheckboxButton.GetAttribute("value")), $"Expected Uncheck All, actual result {_MultiplyCheckboxButton.GetAttribute("value")}");
        }

        public void UncheckAllButton()
        {
            _MultiplyCheckboxButton.Click();
        }

        public void CheckMultiplyCheckboxesStatus()
        {
            foreach (IWebElement checkbox in _checkboxCollection)
            {
                Assert.IsTrue(!checkbox.Selected, "Not all Multiplay chechboxes were unchecked");
            }
        }

    }

}
