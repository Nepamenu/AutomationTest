using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation
{
    class checkBox
    {
        private static IWebDriver _driver;

        [OneTimeSetUp]
        public static void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Url = "https://www.seleniumeasy.com/test/basic-checkbox-demo.html";
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //popUp neissoko, kad testas nefailintu uzkomentuoju

           /* WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(_driver => _driver.FindElement(By.Id("at-cv-lightbox-close")).Displayed);
            _driver.FindElement(By.Id("at-cv-lightbox-close")).Click();*/

        }

        [OneTimeTearDown]
        public static void TearDown()
        {
         //  _driver.Quit();
        }

        // 1) Pažymime “Click on this check box” , patikriname kad atsirado “Success - Check box is checked” pranešimas.
        [Test]
        public static void CheckOneCheckBox()
        {
            IWebElement oneCheckbox = _driver.FindElement(By.Id("isAgeSelected"));
            if (!oneCheckbox.Selected)
            {
                oneCheckbox.Click();
            }
            IWebElement oneCheckResult = _driver.FindElement(By.Id("txtAge"));
            Assert.AreEqual("Success - Check box is checked", oneCheckResult.Text, "Result NOK");

        }

        //2) Pažymime visas “Multiple Checkbox Demo” sekcijos varneles, patikriname kad mygtukas persivadino į “Uncheck All”.

        [Test]
        public static void CheckAllCheckBoxes()
        {
            IWebElement oneCheckbox = _driver.FindElement(By.Id("txtAge"));
            if (oneCheckbox.Selected)
            {
                oneCheckbox.Click();
            }
            
            IReadOnlyCollection<IWebElement> checkboxCollection = _driver.FindElements(By.CssSelector(cssSelectorToFind: ".cb1-element"));
            foreach(IWebElement checkbox in checkboxCollection)
            {
                checkbox.Click();
            }

            IWebElement MultiplyCheckboxBTN = _driver.FindElement(By.Id("check1"));
            Assert.IsTrue(MultiplyCheckboxBTN.GetAttribute("value").Equals("Uncheck All"), $"Expected Uncheck All, actual result {MultiplyCheckboxBTN.GetAttribute("value")}");

        }

        //3) Paspaudžiame mygtuką “Uncheck All” , patikriname kad visos “Multiple Checkbox Demo” sekcijos varneles atžymėtos.
        [Test]

        public static void UncheckAllIsUnchecked()
        {
            IReadOnlyCollection<IWebElement> MultiplyCeckboxes = _driver.FindElements(By.CssSelector(".cb1-element"));
            foreach (IWebElement checkBox  in MultiplyCeckboxes)
            {
                if (!checkBox.Selected)
                {
                    checkBox.Click();
                }
            }
            IWebElement MultiplyCheckboxBTN = _driver.FindElement(By.Id("check1"));
            if(MultiplyCheckboxBTN.GetAttribute("value").Equals("Uncheck All"))
            {
                MultiplyCheckboxBTN.Click();

                Assert.AreEqual("Check All", MultiplyCheckboxBTN.GetAttribute("value"), "Value is not correct");
            }
           
                        
        }


    }
}
