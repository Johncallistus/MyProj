using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTests
{
    [TestFixture]
    public class InsuranceQuoteTests
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost/prog8171_A04");
        }

        [TearDown]
        public void Teardown()
        {
            driver.Quit();
        }

        [Test]
        public void InsuranceQuote01_ValidData()
        {
            // Fill out the form with valid data
            driver.FindElement(By.Id("FirstName")).SendKeys("John");
            driver.FindElement(By.Id("LastName")).SendKeys("Doe");
            driver.FindElement(By.Id("Address")).SendKeys("123 Main St");
            driver.FindElement(By.Id("City")).SendKeys("Anytown");
            driver.FindElement(By.Id("Province")).SendKeys("ON");
            driver.FindElement(By.Id("PostalCode")).SendKeys("N2L 3G1");
            driver.FindElement(By.Id("PhoneNumber")).SendKeys("123-123-1234");
            driver.FindElement(By.Id("EmailAddress")).SendKeys("john.doe@mail.com");
            driver.FindElement(By.Id("Age")).SendKeys("25");
            driver.FindElement(By.Id("Experience")).SendKeys("3");
            driver.FindElement(By.Id("Accidents")).SendKeys("0");

            // Submit the form
            driver.FindElement(By.Id("SubmitButton")).Click();

            // Verify expected outcome
            var result = driver.FindElement(By.Id("ResultText")).Text;
            Assert.AreEqual("Insurance provided; Base rate = $4500", result);
        }
        [Test]
        public void InsuranceQuote02_AccidentsTwo()
        {
            driver.FindElement(By.Id("FirstName")).SendKeys("John");
            driver.FindElement(By.Id("LastName")).SendKeys("Agara");
            driver.FindElement(By.Id("Address")).SendKeys("123 Oak St");
            driver.FindElement(By.Id("City")).SendKeys("Sometown");
            driver.FindElement(By.Id("Province")).SendKeys("ON");
            driver.FindElement(By.Id("PostalCode")).SendKeys("N2L 4G1");
            driver.FindElement(By.Id("PhoneNumber")).SendKeys("(123)123-1234");
            driver.FindElement(By.Id("EmailAddress")).SendKeys("john.agara@mail.com");
            driver.FindElement(By.Id("Age")).SendKeys("25");
            driver.FindElement(By.Id("Experience")).SendKeys("3");
            driver.FindElement(By.Id("Accidents")).SendKeys("2");

            driver.FindElement(By.Id("SubmitButton")).Click();

            var result = driver.FindElement(By.Id("ResultText")).Text;
            Assert.AreEqual("Insurance provided; Base rate = $4500", result);
        }
        [Test]
        public void InsuranceQuote03_AccidentsFour()
        {
            driver.FindElement(By.Id("FirstName")).SendKeys("Jane");
            driver.FindElement(By.Id("LastName")).SendKeys("Doe");
            driver.FindElement(By.Id("Address")).SendKeys("456 Elm St");
            driver.FindElement(By.Id("City")).SendKeys("Yourtown");
            driver.FindElement(By.Id("Province")).SendKeys("BC");
            driver.FindElement(By.Id("PostalCode")).SendKeys("V3L 1A4");
            driver.FindElement(By.Id("PhoneNumber")).SendKeys("123-555-1234");
            driver.FindElement(By.Id("EmailAddress")).SendKeys("jane.doe@mail.com");
            driver.FindElement(By.Id("Age")).SendKeys("35");
            driver.FindElement(By.Id("Experience")).SendKeys("10");
            driver.FindElement(By.Id("Accidents")).SendKeys("4");

            driver.FindElement(By.Id("SubmitButton")).Click();

            var result = driver.FindElement(By.Id("ResultText")).Text;
            Assert.AreEqual("Insurance not provided", result);
        }

        [Test]
        public void InsuranceQuote04_InvalidPhoneNumber()
        {
            driver.FindElement(By.Id("FirstName")).SendKeys("Mike");
            driver.FindElement(By.Id("LastName")).SendKeys("Smith");
            driver.FindElement(By.Id("Address")).SendKeys("789 Pine St");
            driver.FindElement(By.Id("City")).SendKeys("Smalltown");
            driver.FindElement(By.Id("Province")).SendKeys("AB");
            driver.FindElement(By.Id("PostalCode")).SendKeys("A1B 2C3");
            driver.FindElement(By.Id("PhoneNumber")).SendKeys("12345"); // Invalid
            driver.FindElement(By.Id("EmailAddress")).SendKeys("mike.smith@mail.com");
            driver.FindElement(By.Id("Age")).SendKeys("27");
            driver.FindElement(By.Id("Experience")).SendKeys("3");
            driver.FindElement(By.Id("Accidents")).SendKeys("0");

            driver.FindElement(By.Id("SubmitButton")).Click();

            var result = driver.FindElement(By.Id("ErrorText")).Text;
            Assert.AreEqual("Invalid phone number format", result);
        }
        [Test]
        public void InsuranceQuote05_InvalidEmailAddress()
        {
            driver.FindElement(By.Id("FirstName")).SendKeys("Anna");
            driver.FindElement(By.Id("LastName")).SendKeys("Jones");
            driver.FindElement(By.Id("Address")).SendKeys("987 Willow St");
            driver.FindElement(By.Id("City")).SendKeys("Bigcity");
            driver.FindElement(By.Id("Province")).SendKeys("QC");
            driver.FindElement(By.Id("PostalCode")).SendKeys("H3Z 2X1");
            driver.FindElement(By.Id("PhoneNumber")).SendKeys("(987)654-3210");
            driver.FindElement(By.Id("EmailAddress")).SendKeys("anna.jones"); // Invalid
            driver.FindElement(By.Id("Age")).SendKeys("28");
            driver.FindElement(By.Id("Experience")).SendKeys("3");
            driver.FindElement(By.Id("Accidents")).SendKeys("0");

            driver.FindElement(By.Id("SubmitButton")).Click();

            var result = driver.FindElement(By.Id("ErrorText")).Text;
            Assert.AreEqual("Invalid email address", result);
        }
        [Test]
        public void InsuranceQuote06_InvalidPostalCode()
        {
            driver.FindElement(By.Id("FirstName")).SendKeys("Sarah");
            driver.FindElement(By.Id("LastName")).SendKeys("Connor");
            driver.FindElement(By.Id("Address")).SendKeys("22 High St");
            driver.FindElement(By.Id("City")).SendKeys("Middletown");
            driver.FindElement(By.Id("Province")).SendKeys("NS");
            driver.FindElement(By.Id("PostalCode")).SendKeys("ABC123"); // Invalid
            driver.FindElement(By.Id("PhoneNumber")).SendKeys("123-456-7890");
            driver.FindElement(By.Id("EmailAddress")).SendKeys("sarah.connor@mail.com");
            driver.FindElement(By.Id("Age")).SendKeys("35");
            driver.FindElement(By.Id("Experience")).SendKeys("17");
            driver.FindElement(By.Id("Accidents")).SendKeys("1");

            driver.FindElement(By.Id("SubmitButton")).Click();

            var result = driver.FindElement(By.Id("ErrorText")).Text;
            Assert.AreEqual("Invalid postal code format", result);
        }
        [Test]
        public void InsuranceQuote07_AgeOmitted()
        {
            driver.FindElement(By.Id("FirstName")).SendKeys("Tom");
            driver.FindElement(By.Id("LastName")).SendKeys("Hanks");
            driver.FindElement(By.Id("Address")).SendKeys("55 Hollywood Blvd");
            driver.FindElement(By.Id("City")).SendKeys("Los Angeles");
            driver.FindElement(By.Id("Province")).SendKeys("CA");
            driver.FindElement(By.Id("PostalCode")).SendKeys("90210");
            driver.FindElement(By.Id("PhoneNumber")).SendKeys("(555)555-5555");
            driver.FindElement(By.Id("EmailAddress")).SendKeys("tom.hanks@mail.com");
            driver.FindElement(By.Id("Experience")).SendKeys("5");
            driver.FindElement(By.Id("Accidents")).SendKeys("0");

            driver.FindElement(By.Id("SubmitButton")).Click();

            var result = driver.FindElement(By.Id("ErrorText")).Text;
            Assert.AreEqual("Age is required", result);
        }
        [Test]
        public void InsuranceQuote08_AccidentsOmitted()
        {
            driver.FindElement(By.Id("FirstName")).SendKeys("Emma");
            driver.FindElement(By.Id("LastName")).SendKeys("Watson");
            driver.FindElement(By.Id("Address")).SendKeys("12 Privet Drive");
            driver.FindElement(By.Id("City")).SendKeys("Little Whinging");
            driver.FindElement(By.Id("Province")).SendKeys("ON");
            driver.FindElement(By.Id("PostalCode")).SendKeys("N2L 5G3");
            driver.FindElement(By.Id("PhoneNumber")).SendKeys("789-456-1230");
            driver.FindElement(By.Id("EmailAddress")).SendKeys("emma.watson@mail.com");
            driver.FindElement(By.Id("Age")).SendKeys("37");
            driver.FindElement(By.Id("Experience")).SendKeys("8");

            driver.FindElement(By.Id("SubmitButton")).Click();

            var result = driver.FindElement(By.Id("ErrorText")).Text;
            Assert.AreEqual("Accidents field is required", result);
        }
        [Test]
        public void InsuranceQuote09_ExperienceOmitted()
        {
            driver.FindElement(By.Id("FirstName")).SendKeys("Robert");
            driver.FindElement(By.Id("LastName")).SendKeys("Downey");
            driver.FindElement(By.Id("Address")).SendKeys("1 Stark Tower");
            driver.FindElement(By.Id("City")).SendKeys("New York");
            driver.FindElement(By.Id("Province")).SendKeys("NY");
            driver.FindElement(By.Id("PostalCode")).SendKeys("10101");
            driver.FindElement(By.Id("PhoneNumber")).SendKeys("212-555-1234");
            driver.FindElement(By.Id("EmailAddress")).SendKeys("robert.downey@mail.com");
            driver.FindElement(By.Id("Age")).SendKeys("45");
            driver.FindElement(By.Id("Accidents")).SendKeys("0");

            driver.FindElement(By.Id("SubmitButton")).Click();

            var result = driver.FindElement(By.Id("ErrorText")).Text;
            Assert.AreEqual("Experience field is required", result);
        }
        [Test]
        public void InsuranceQuote10_AgeAndExperienceMismatch()
        {
            driver.FindElement(By.Id("FirstName")).SendKeys("Chris");
            driver.FindElement(By.Id("LastName")).SendKeys("Evans");
            driver.FindElement(By.Id("Address")).SendKeys("1 Shield Lane");
            driver.FindElement(By.Id("City")).SendKeys("Brooklyn");
            driver.FindElement(By.Id("Province")).SendKeys("NY");
            driver.FindElement(By.Id("PostalCode")).SendKeys("11201");
            driver.FindElement(By.Id("PhoneNumber")).SendKeys("(212)789-6543");
            driver.FindElement(By.Id("EmailAddress")).SendKeys("chris.evans@mail.com");
            driver.FindElement(By.Id("Age")).SendKeys("30");
            driver.FindElement(By.Id("Experience")).SendKeys("20"); // Invalid mismatch
            driver.FindElement(By.Id("Accidents")).SendKeys("0");

            driver.FindElement(By.Id("SubmitButton")).Click();

            var result = driver.FindElement(By.Id("ErrorText")).Text;
            Assert.AreEqual("Experience cannot exceed (Age - 16)", result);
        }
        [Test]
        public void InsuranceQuote11_ValidDataWithRateReduction()
        {
            driver.FindElement(By.Id("FirstName")).SendKeys("Natasha");
            driver.FindElement(By.Id("LastName")).SendKeys("Romanoff");
            driver.FindElement(By.Id("Address")).SendKeys("100 Spy Lane");
            driver.FindElement(By.Id("City")).SendKeys("RedRoom");
            driver.FindElement(By.Id("Province")).SendKeys("ON");
            driver.FindElement(By.Id("PostalCode")).SendKeys("N2L 6G7");
            driver.FindElement(By.Id("PhoneNumber")).SendKeys("416-456-7890");
            driver.FindElement(By.Id("EmailAddress")).SendKeys("natasha.romanoff@mail.com");
            driver.FindElement(By.Id("Age")).SendKeys("40");
            driver.FindElement(By.Id("Experience")).SendKeys("15");
            driver.FindElement(By.Id("Accidents")).SendKeys("0");

            driver.FindElement(By.Id("SubmitButton")).Click();

            var result = driver.FindElement(By.Id("ResultText")).Text;
            Assert.AreEqual("Insurance provided; Base rate = $3000; Rate reduction applied = $2190", result);
        }
        [Test]
        public void InsuranceQuote12_NoExperience_BaseRate6000()
        {
            driver.FindElement(By.Id("FirstName")).SendKeys("Bruce");
            driver.FindElement(By.Id("LastName")).SendKeys("Wayne");
            driver.FindElement(By.Id("Address")).SendKeys("1 Gotham Manor");
            driver.FindElement(By.Id("City")).SendKeys("Gotham");
            driver.FindElement(By.Id("Province")).SendKeys("ON");
            driver.FindElement(By.Id("PostalCode")).SendKeys("N5L 2B1");
            driver.FindElement(By.Id("PhoneNumber")).SendKeys("123-654-7890");
            driver.FindElement(By.Id("EmailAddress")).SendKeys("bruce.wayne@mail.com");
            driver.FindElement(By.Id("Age")).SendKeys("25");
            driver.FindElement(By.Id("Experience")).SendKeys("0"); // No experience
            driver.FindElement(By.Id("Accidents")).SendKeys("0");

            driver.FindElement(By.Id("SubmitButton")).Click();

            var result = driver.FindElement(By.Id("ResultText")).Text;
            Assert.AreEqual("Insurance provided; Base rate = $6000", result);
        }
        [Test]
        public void InsuranceQuote13_NoAccidents_BaseRate3000()
        {
            driver.FindElement(By.Id("FirstName")).SendKeys("Steve");
            driver.FindElement(By.Id("LastName")).SendKeys("Rogers");
            driver.FindElement(By.Id("Address")).SendKeys("123 Shield Ave");
            driver.FindElement(By.Id("City")).SendKeys("Brooklyn");
            driver.FindElement(By.Id("Province")).SendKeys("ON");
            driver.FindElement(By.Id("PostalCode")).SendKeys("N1L 4F5");
            driver.FindElement(By.Id("PhoneNumber")).SendKeys("416-789-4567");
            driver.FindElement(By.Id("EmailAddress")).SendKeys("steve.rogers@mail.com");
            driver.FindElement(By.Id("Age")).SendKeys("50");
            driver.FindElement(By.Id("Experience")).SendKeys("20");
            driver.FindElement(By.Id("Accidents")).SendKeys("0"); // No accidents

            driver.FindElement(By.Id("SubmitButton")).Click();

            var result = driver.FindElement(By.Id("ResultText")).Text;
            Assert.AreEqual("Insurance provided; Base rate = $3000", result);
        }
        [Test]
        public void InsuranceQuote14_ValidDataWithOneAccident()
        {
            driver.FindElement(By.Id("FirstName")).SendKeys("Clint");
            driver.FindElement(By.Id("LastName")).SendKeys("Barton");
            driver.FindElement(By.Id("Address")).SendKeys("123 Archer St");
            driver.FindElement(By.Id("City")).SendKeys("Smalltown");
            driver.FindElement(By.Id("Province")).SendKeys("AB");
            driver.FindElement(By.Id("PostalCode")).SendKeys("T2B 1A3");
            driver.FindElement(By.Id("PhoneNumber")).SendKeys("(987)654-3210");
            driver.FindElement(By.Id("EmailAddress")).SendKeys("clint.barton@mail.com");
            driver.FindElement(By.Id("Age")).SendKeys("35");
            driver.FindElement(By.Id("Experience")).SendKeys("10");
            driver.FindElement(By.Id("Accidents")).SendKeys("1"); // One accident

            driver.FindElement(By.Id("SubmitButton")).Click();

            var result = driver.FindElement(By.Id("ResultText")).Text;
            Assert.AreEqual("Insurance provided; Base rate = $3000", result);
        }
        [Test]
        public void InsuranceQuote15_ThreeAccidents_InsuranceDenied()
        {
            driver.FindElement(By.Id("FirstName")).SendKeys("Peter");
            driver.FindElement(By.Id("LastName")).SendKeys("Parker");
            driver.FindElement(By.Id("Address")).SendKeys("20 Queens Blvd");
            driver.FindElement(By.Id("City")).SendKeys("Queens");
            driver.FindElement(By.Id("Province")).SendKeys("ON");
            driver.FindElement(By.Id("PostalCode")).SendKeys("N4G 6H8");
            driver.FindElement(By.Id("PhoneNumber")).SendKeys("123-456-9876");
            driver.FindElement(By.Id("EmailAddress")).SendKeys("peter.parker@mail.com");
            driver.FindElement(By.Id("Age")).SendKeys("30");
            driver.FindElement(By.Id("Experience")).SendKeys("5");
            driver.FindElement(By.Id("Accidents")).SendKeys("3"); // Three accidents

            driver.FindElement(By.Id("SubmitButton")).Click();

            var result = driver.FindElement(By.Id("ResultText")).Text;
            Assert.AreEqual("Insurance not provided", result);
        }


        // Additional tests go here...
    }
}

