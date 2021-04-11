/* 2021-04-12 Automated Testing VCS
   Student Jurate B.
   testing www.luminor.lt 
   5 different Tests 
 */


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
        // Nr. 1. Testing Luminor contacts and main contact phone number
        [Test]
        public static void TestContactNumber()
        {
            _demoLuminorMainPage.NavigateToDefaultPage()
                .ClickPhoneIcon()
                .ClickKontaktaiLink()
                .VerifyContactPhoneNr();
        }

        // Nr. 2. Testing Luminor monthly paymant for loan for car with different parameters (editing loan amount and loan term)

        [TestCase("10000", "12", "884", TestName = "Paskolos suma 10 000 EUR laikotarpis 12 men, menesine imoka 884 EUR")]
        [TestCase("10000", "24", "466", TestName = "Paskolos suma 10 000 EUR laikotarpis 24 men, menesine imoka 466 EUR")]
        [TestCase("10000", "30", "383", TestName = "Paskolos suma 10 000 EUR laikotarpis 30 men, menesine imoka 383 EUR")]
        [TestCase("15000", "12", "1 326", TestName = "Paskolos suma 15 000 EUR laikotarpis 12 men, menesine imoka 1 326 EUR")]
        [TestCase("15000", "24", "699", TestName = "Paskolos suma 15 000 EUR laikotarpis 24 men, menesine imoka 699 EUR")]


        public static void TestMonthlyPaymantForCarLoan(string loan, string term, string result)
        {
            _demoLuminorPaskolaAutoPage.NavigateToDefaultPage()
                .SetLoanAmount(loan)
                .SetTerm(term)
                .VerifyMonthlyPayment(result);

        }

        // Nr. 3. Testing Luminor registration to consultation by filling the registration form

        [TestCase("Tadas", "Tadukas", "19900101", "861212345", false, "Konsultacija dėl pensijų kaupimo", TestName = "Registration to consultation")]
        [TestCase("Tomas", "Tomukas", "20000303", "861111111", false, "Konsultacija dėl pensijų kaupimo", TestName = "Registration to consultation")]

        public static void TestRegistrationToConsultation(string name, string surname, string birthday, string phone, bool shouldBeChecked, string result)
        {
            _demoRegistracijaKonsultacijaiPage.NavigateToDefaultPage()
                .CleanInputFields()
                .SetInputFields(name, surname, birthday, phone)
                .ClickSubmitButton()
                .VerifyRegistrationStatus(result);

        }

        // Nr. 4.  Testing Luminor  the sodra part in the wanted pension with different parameters (wanted pension,neto salary, age, work experience, gender

        [TestCase("1000", "30", "800", "10", true, "620", TestName = "Norima pensija 1000 EUR, amzius 30, dabartine alga i rankas 800 EUR darbo stazas 10 metu. Moteris. Sodra mokes 620")]
        [TestCase("1000", "40", "800", "20", false, "560", TestName = "Norima pensija 1000 EUR, amzius 40, dabartine alga i rankas 800 EUR darbo stazas 20 metu. Vyras Sodra mokes 620")]
        public static void TestExpectedPensionFromSodra(string expectedAmount, string age, string salary, string workExperience, bool gender, string result)
        {
            _demoPensijuSkaiciuoklePage.NavigateToDefaultPage()
                .ClearInputFields()
                .SetExpectedPension(expectedAmount)
                .SetAge(age)
                .SetSalary(salary)
                .SetWorkExperience(workExperience)
                .SetGender(gender)
                .ClickCalculateButton()
                .CheckSodrosPensija(result);

        }

      
        // Nr. 5. Testing Luminor Search output with null input value
        [Test]

        public static void TestSearchErrorMessage()
        {
            _demoLuminoPaieskaPage.NavigateToDefaultPage()
                .ClearInputField()
                .WriteTextToFind()
                .ClickSearchButton()
                .VerfifyErrorMessage();
        }

        // Nr. 6. optional Testing Luminor login to account with null ID number

        [Test]
        public static void TestLoginToBankAcount()
        {
            _demoLuminorInternetoBankasPage.NavigateToDefaultPage()               
                .ClickLoginButton()
                .VerifyErrorMessage();

        }

    }
}
