using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Page
{
    public class DemoLuminorPaskolaAutoPage : BasePage
    {
        private const string PageAddress = "https://www.luminor.lt/lt/privatiems/vartojimo-paskola-automobiliui";

        private IWebElement _loanAmount => Driver.FindElement(By.Id("edit-loan-amount"));
        private IWebElement _loanTerm => Driver.FindElement(By.Id("edit-loan-term"));

        private IWebElement _resultMonthlyPayment => Driver.FindElement(By.CssSelector("#edit-summary > p.summary__primary > span"));

        public DemoLuminorPaskolaAutoPage(IWebDriver webdriver) : base(webdriver) { }
        public DemoLuminorPaskolaAutoPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
            {
                Driver.Url = PageAddress;
            }
            return this;
        }

        public DemoLuminorPaskolaAutoPage ClearInputFields()
        {
            _loanAmount.Clear();
            _loanTerm.Clear();
            return this;
        }


        public DemoLuminorPaskolaAutoPage SetLoanAmountAndTerm (string loan, string term)
        {
            SetLoanAmount(loan);
            SetLoanTerm(term);
            return this;
        }
        public DemoLuminorPaskolaAutoPage VerifyMonthlyPayment (string monthlyPayment)
        {
            Assert.AreEqual(monthlyPayment, _resultMonthlyPayment.Text, "Monthly Payment are not equal");
            return this;
        }
        private DemoLuminorPaskolaAutoPage SetLoanAmount(string loan)
        {
            _loanAmount.SendKeys(loan);
            return this;
        }

        private DemoLuminorPaskolaAutoPage SetLoanTerm(string term)
        {
            _loanTerm.SendKeys(term);
            return this;
        }

       

    }
}
