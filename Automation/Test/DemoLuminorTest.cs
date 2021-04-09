using Automation.Page;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Test
{
    class DemoLuminorTest : BaseTest
    {
        [Test]
        public static void TestContactNumber()
        {
            _demoLuminorMainPage.NavigateToDefaultPage()
                .ClickPhoneIcon()
                .ClickKontaktaiLink()
                .VerifyContactPhoneNr();
        }

        
        [TestCase("10000", "12", "884", TestName = "Paskolos suma 10 000 EUR laikotarpis 12 men, menesine imoka 884 EUR")]
        [TestCase("10000", "24", "466", TestName = "Paskolos suma 10 000 EUR laikotarpis 24 men, menesine imoka 466 EUR")]
        [TestCase("10000", "30", "383", TestName = "Paskolos suma 10 000 EUR laikotarpis 30 men, menesine imoka 383 EUR")]
        [TestCase("15000", "12", "1326", TestName = "Paskolos suma 15 000 EUR laikotarpis 12 men, menesine imoka 1326 EUR")]
        [TestCase("15000", "24", "699", TestName = "Paskolos suma 15 000 EUR laikotarpis 24 men, menesine imoka 699 EUR")]


        public static void TestMonthlyPaymantForCarLoan(string loan, string term, string result)
        {
            _demoLuminorPaskolaAutoPage.NavigateToDefaultPage()
                .ClearInputFields()
                .SetLoanAmountAndTerm(loan, term)
                .VerifyMonthlyPayment(result);

        }
    }
}
