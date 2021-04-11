/* 2021-04-12 Jurate B. Automated Testing Final Project
 * Testing Luminor  the sodra part in the wanted pension with different parameters (wanted pension,neto salary, age, work experience, gender  */
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Automation.Page
{
    public class DemoPensijuSkaiciuoklePage : BasePage
    {
        private const string PageAddress = "https://www.luminor.lt/lt/privatiems/pensiju-skaiciuokle";

        private IWebElement _expectedPension => Driver.FindElement(By.Id("edit-expected-pension"));
        private IWebElement _editAge => Driver.FindElement(By.Id("edit-age"));
        private IWebElement _netSalary => Driver.FindElement(By.Id("edit-net-salary"));
        private IWebElement _workExperience => Driver.FindElement(By.Id("edit-work-experience"));
        private IWebElement _genderWoman => Driver.FindElement(By.CssSelector("li:nth-child(1) > .option:nth-child(2)"));
        // private IWebElement _genderMan => Driver.FindElement(By.CssSelector("#edit-work-experience-grid > div:nth-child(2) > ul > li:nth-child(2) > label"));
        private IWebElement _calculateButton => Driver.FindElement(By.Id("edit-submit"));
        private IWebElement _sodrosPensija => Driver.FindElement(By.CssSelector(".pension-result-amount"));
        public DemoPensijuSkaiciuoklePage(IWebDriver webdriver) : base(webdriver) { }
        public DemoPensijuSkaiciuoklePage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
            {
                Driver.Url = PageAddress;
            }
            return this;
        }

        public DemoPensijuSkaiciuoklePage ClearInputFields()
        {
            _expectedPension.Clear();
            _editAge.Clear();
            _netSalary.Clear();
            _workExperience.Clear();
            return this;
        }

        /* public DemoPensijuSkaiciuoklePage SetValuesForCalculation(string pension, string age, string salary, string experience)
         {
             SetExpectedPension(pension);
             SetAge(age);
             SetSalary(salary);
             SetWorkExperience(experience);
             return this;
         }*/


        public DemoPensijuSkaiciuoklePage SetExpectedPension(string pension)
        {
            _expectedPension.SendKeys(pension);
            return this;
        }

        public DemoPensijuSkaiciuoklePage SetAge(string age)
        {
            _editAge.SendKeys(age);
            return this;
        }

        public DemoPensijuSkaiciuoklePage SetSalary(string salary)
        {
            _netSalary.SendKeys(salary);
            return this;
        }

        public DemoPensijuSkaiciuoklePage SetWorkExperience(string experience)
        {
            _workExperience.Clear();
            _workExperience.SendKeys(experience);
            return this;
        }

        public DemoPensijuSkaiciuoklePage SetGender(bool gender)
        {
            if (gender)
            {
                _genderWoman.Click();

            }

            return this;
        }

        public DemoPensijuSkaiciuoklePage ClickCalculateButton()
        {
            _calculateButton.Click();
            return this;
        }

        public DemoPensijuSkaiciuoklePage CheckSodrosPensija(string result)
        {
            Thread.Sleep(10000);
            /*WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(1000));
              wait.Until(ExpectedConditions.TextToBePresentInElement(_sodrosPensija,result));
              GetWait(10).Until(ExpectedConditions.TextToBePresentInElement(_sodrosPensija ,result));*/

            Assert.IsTrue(_sodrosPensija.Text.Contains(result), "Pension Values are not equal");
            return this;
        }
    }
}
