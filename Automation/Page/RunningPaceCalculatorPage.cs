/* 3. Automation Lesson
   1 optional task:  patikrinti, ar nubėgus 13km per 1val 5min vieno kilometro greitis yra 5min/km

 
 */

using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Page
{
    public class RunningPaceCalculatorPage : BasePage
    {
        private IWebElement _timeHour => Driver.FindElement(By.CssSelector("#calculator-pace > form > div:nth-child(2) > div > label:nth-child(1) > input[type=number]"));

        private IWebElement _timeMinutes => Driver.FindElement(By.CssSelector("#calculator-pace > form > div:nth-child(2) > div > label:nth-child(2) > input[type=number]"));

        private IWebElement _distance => Driver.FindElement(By.CssSelector("#calculator-pace > form > div:nth-child(3) > div > label > input[type=number]"));

        private IWebElement _distanceDropDown => Driver.FindElement(By.CssSelector("#calculator-pace > form > div:nth-child(3) > div > span > span"));
        private IWebElement _distanceKM => Driver.FindElement(By.CssSelector("#calculator-pace > form > div:nth-child(3) > div > span > ul > li.selectboxit-option.selectboxit-option-first"));

        private IWebElement _paceDropDown => Driver.FindElement(By.CssSelector("#calculator-pace > form > div:nth-child(4) > div > span > span > span.selectboxit-arrow-container"));

        private IWebElement _paceHours => Driver.FindElement(By.CssSelector("#calculator-pace > form > div:nth-child(4) > div > label:nth-child(1) > input[type=number]"));

        private IWebElement _paceMinutes => Driver.FindElement(By.CssSelector("#calculator-pace > form > div:nth-child(4) > div > label:nth-child(2) > input[type=number]"));

        private IWebElement _paceSeconds => Driver.FindElement(By.CssSelector("#calculator-pace > form > div:nth-child(4) > div > label:nth-child(3) > input[type=number]"));

        private IWebElement _paceKM => Driver.FindElement(By.CssSelector("#calculator-pace > form > div:nth-child(4) > div > span > span > span.selectboxit-text"));

        private IWebElement _calculateButton => Driver.FindElement(By.CssSelector("#calculator-pace > form > div:nth-child(6) > div > a"));

        private IWebElement _resetButton => Driver.FindElement(By.ClassName("#calculator-pace > form > div:nth-child(6) > div > span > a"));


        public RunningPaceCalculatorPage(IWebDriver webdriver) : base(webdriver) { } // constructor + base page constructor 
                                                                                     // patikrinti, ar nubėgus 13km per 1val 5min vieno kilometro greitis yra 5min/km


        public void ResetValues()
        {
            _resetButton.Click();
        }

        public void SetTimeValues (string hour, string minutes)
        {            
            _timeHour.SendKeys(hour);
            _timeMinutes.SendKeys(minutes);
        }

        public void SetDistance(string distance)
        {
            _distance.SendKeys(distance);
            _distanceDropDown.Click(); //ar galima si veiksma praleisti?
            _distanceKM.Click();
        }

        public void SetPaceKM()
        {
            _paceDropDown.Click(); // ar galima isvengti
            _paceKM.Click();
        }

        //kaip galima optimizuoti asserta skirtingiems inputams

        public void CheckResult(string resultHour, string resultMinutes, string resultSeconds)
        {
            Calculate();
            Assert.AreEqual(resultHour, _paceHours.Text, "Hours are not equal");
            Assert.AreEqual(resultMinutes, _paceMinutes.Text, "Minutes are not equal");
            Assert.AreEqual(resultSeconds, _paceSeconds.Text, "Seconds are not equal");
        }

        private void Calculate()
        {
            _calculateButton.Click();
        }

    }
}
