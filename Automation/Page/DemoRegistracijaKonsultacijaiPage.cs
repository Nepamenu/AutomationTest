using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Page
{
    public class DemoRegistracijaKonsultacijaiPage : BasePage
    {
        private const string PageAddress = "https://www.luminor.lt/lt/konsultacija-del-pensiju-kaupimo";

        private IWebElement _name => Driver.FindElement(By.Id("edit-submitted-vardas"));
        private IWebElement _surname => Driver.FindElement(By.Id("edit-submitted-pavarde"));
        private IWebElement _birthday => Driver.FindElement(By.Id("edit-submitted-gimimo-data"));
        private IWebElement _phoneNr => Driver.FindElement(By.Id("edit-submitted-370"));
        private IWebElement _checkboxSubmitted => Driver.FindElement(By.Id("edit-submitted-sutikimas-1"));
        private IWebElement _submitButton => Driver.FindElement(By.Id("edit-webform-ajax-submit-13825"));
       // private IWebElement _resultMessage => Driver.FindElement(By.CssSelector("#webform-ajax-wrapper-13825 > div.l-wrap.clearfix > p"));
        private IWebElement _resultMessage => Driver.FindElement(By.CssSelector("p:nth-child(2)"));

        //Susisieksime su tavimi per 1 darbo dieną.


        public DemoRegistracijaKonsultacijaiPage(IWebDriver webdriver) : base(webdriver) { }
        public DemoRegistracijaKonsultacijaiPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
            {
                Driver.Url = PageAddress;
            }
            return this;
        }

        public DemoRegistracijaKonsultacijaiPage CleanInputFields()
        {
            CleanNameField();
            CleanSurnameField();
            CleanBirthdayField();
            CleanPhoneNrField();
            return this;
        }

        public DemoRegistracijaKonsultacijaiPage SetInputFields(string name, string surname, string birthday, string phone)
        {
            _name.SendKeys(name);
            _surname.SendKeys(surname);
            _birthday.SendKeys(birthday);
            _phoneNr.SendKeys(phone);
            return this;
        }

        public DemoRegistracijaKonsultacijaiPage ClickSubmittedCheckbox(bool shouldBeChecked)
        {
            if (shouldBeChecked != _checkboxSubmitted.Selected)
            {
                _checkboxSubmitted.Click();
            }
            return this;
        }

        public DemoRegistracijaKonsultacijaiPage ClickSubmitButton()
        {
            _submitButton.Click();
            return this;
        }

        public DemoRegistracijaKonsultacijaiPage VerifyRegistrationStatus(string result)
        {
            Assert.AreEqual(result, _resultMessage.Text, "Registration was not succesfull");
            return this;
        }

        private DemoRegistracijaKonsultacijaiPage CleanNameField()
        {
            _name.Click();
            _name.Clear();
            return this;
        }
        private DemoRegistracijaKonsultacijaiPage CleanSurnameField()
        {
            _surname.Click();
            _surname.Clear();
            return this;
        }

        private DemoRegistracijaKonsultacijaiPage CleanBirthdayField()
        {
            _birthday.Click();
            _birthday.Clear();
            return this;
        }

        private DemoRegistracijaKonsultacijaiPage CleanPhoneNrField()
        {
            _phoneNr.Click();
            _phoneNr.Clear();
            return this;
        }
    }
}

