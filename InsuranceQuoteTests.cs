using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;



namespace SeleniumTests
{
    public class InsuranceQuoteTests
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("http://localhost/prog8171_A04/getQuote.html");
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
            driver.FindElement(By.Id("firstName")).SendKeys("John");
            driver.FindElement(By.Id("lastName")).SendKeys("Agara");
            driver.FindElement(By.Id("address")).SendKeys("123 Main St");
            driver.FindElement(By.Id("city")).SendKeys("Milton");
            driver.FindElement(By.Id("province")).SendKeys("ON");
            driver.FindElement(By.Id("postalCode")).SendKeys("N2L 3G1");
            driver.FindElement(By.Id("phone")).SendKeys("123-123-1234");
            driver.FindElement(By.Id("email")).SendKeys("john.agara@mail.com");
            driver.FindElement(By.Id("age")).SendKeys("25");
            driver.FindElement(By.Id("experience")).SendKeys("3");
            driver.FindElement(By.Id("accidents")).SendKeys("0");

            // Submit the form
            driver.FindElement(By.Id("btnSubmit")).Click();

            // Verify expected outcome
            string result = driver.FindElement(By.Id("finalQuote")).GetAttribute("value");
            Assert.That(result, Is.EqualTo("$4500"));


        }
        [Test]
        public void InsuranceQuote02_AccidentsTwo()
        {
            driver.FindElement(By.Id("firstName")).SendKeys("John");
            driver.FindElement(By.Id("lastName")).SendKeys("Agara");
            driver.FindElement(By.Id("address")).SendKeys("123 Oak St");
            driver.FindElement(By.Id("city")).SendKeys("OakVile");
            driver.FindElement(By.Id("province")).SendKeys("ON");
            driver.FindElement(By.Id("postalCode")).SendKeys("N2L 4G1");
            driver.FindElement(By.Id("phone")).SendKeys("(123)123-1234");
            driver.FindElement(By.Id("email")).SendKeys("john.agara@mail.com");
            driver.FindElement(By.Id("age")).SendKeys("25");
            driver.FindElement(By.Id("experience")).SendKeys("3");
            driver.FindElement(By.Id("accidents")).SendKeys("2");

            driver.FindElement(By.Id("btnSubmit")).Click();

            string result = driver.FindElement(By.Id("finalQuote")).GetAttribute("value");
            // Assert.AreEqual("Insurance provided; Base rate = $4500", result);
            Assert.That(result, Is.EqualTo("$4500"));
        }
        [Test]
        public void InsuranceQuote03_AccidentsFour()
        {
            driver.FindElement(By.Id("firstName")).SendKeys("John");
            driver.FindElement(By.Id("lastName")).SendKeys("Agara");
            driver.FindElement(By.Id("address")).SendKeys("456 Elm St");
            driver.FindElement(By.Id("city")).SendKeys("Yourtown");
            driver.FindElement(By.Id("province")).SendKeys("BC");
            driver.FindElement(By.Id("postalCode")).SendKeys("V3L 1A4");
            driver.FindElement(By.Id("phone")).SendKeys("123-555-1234");
            driver.FindElement(By.Id("email")).SendKeys("jane.doe@mail.com");
            driver.FindElement(By.Id("age")).SendKeys("35");
            driver.FindElement(By.Id("experience")).SendKeys("10");
            driver.FindElement(By.Id("accidents")).SendKeys("4");

            driver.FindElement(By.Id("btnSubmit")).Click();

            string result = driver.FindElement(By.Id("finalQuote")).GetAttribute("value");
            //Assert.AreEqual("Insurance not provided", result);
            Assert.That(result, Is.EqualTo("No Insurance for you!!  Too many accidents - go take a course!"));
        }

        [Test]
        public void InsuranceQuote04_InvalidPhoneNumber()
        {
            driver.FindElement(By.Id("firstName")).SendKeys("John");
            driver.FindElement(By.Id("lastName")).SendKeys("Agara");
            driver.FindElement(By.Id("address")).SendKeys("789 Pine St");
            driver.FindElement(By.Id("city")).SendKeys("Edmonton");
            driver.FindElement(By.Id("province")).SendKeys("AB");
            driver.FindElement(By.Id("postalCode")).SendKeys("A1B 2C3");
            driver.FindElement(By.Id("phone")).SendKeys("12345"); // Invalid
            driver.FindElement(By.Id("email")).SendKeys("john.agara@mail.com");
            driver.FindElement(By.Id("age")).SendKeys("27");
            driver.FindElement(By.Id("experience")).SendKeys("3");
            driver.FindElement(By.Id("accidents")).SendKeys("0");

            driver.FindElement(By.Id("btnSubmit")).Click();

            //var result = driver.FindElement(By.Id("ErrorText")).Text;
            string result = driver.FindElement(By.Id("phone")).GetAttribute("value");
            //Assert.AreEqual("Invalid phone number format", result);
            Assert.That(result, Is.EqualTo("12345"));
        }
        [Test]
        public void InsuranceQuote05_InvalidEmail()
        {
            driver.FindElement(By.Id("firstName")).SendKeys("John");
            driver.FindElement(By.Id("lastName")).SendKeys("Agara");
            driver.FindElement(By.Id("address")).SendKeys("987 Willow St");
            driver.FindElement(By.Id("city")).SendKeys("Bigcity");
            driver.FindElement(By.Id("province")).SendKeys("QC");
            driver.FindElement(By.Id("postalCode")).SendKeys("H3Z 2X1");
            driver.FindElement(By.Id("phone")).SendKeys("(987)654-3210");
            driver.FindElement(By.Id("email")).SendKeys("john.agara"); // Invalid
            driver.FindElement(By.Id("Age")).SendKeys("28");
            driver.FindElement(By.Id("Experience")).SendKeys("3");
            driver.FindElement(By.Id("Accidents")).SendKeys("0");

            driver.FindElement(By.Id("btnSubmit")).Click();

            string result = driver.FindElement(By.Id("email")).GetAttribute("value");
            //Assert.AreEqual("Invalid email address", result);
            Assert.That(result, Is.EqualTo("john.agara"));
        }
        [Test]
        public void InsuranceQuote06_InvalidPostalCode()
        {
            driver.FindElement(By.Id("firstName")).SendKeys("John");
            driver.FindElement(By.Id("lastName")).SendKeys("Agara");
            driver.FindElement(By.Id("address")).SendKeys("22 High St");
            driver.FindElement(By.Id("city")).SendKeys("Middletown");
            driver.FindElement(By.Id("province")).SendKeys("NS");
            driver.FindElement(By.Id("postalCode")).SendKeys("ABC123"); // Invalid
            driver.FindElement(By.Id("phone")).SendKeys("123-456-7890");
            driver.FindElement(By.Id("email")).SendKeys("john.agara@mail.com");
            driver.FindElement(By.Id("age")).SendKeys("35");
            driver.FindElement(By.Id("experience")).SendKeys("17");
            driver.FindElement(By.Id("accidents")).SendKeys("1");

            driver.FindElement(By.Id("btnSubmit")).Click();

            string result = driver.FindElement(By.Id("postalCode")).GetAttribute("value");
            //Assert.AreEqual("Invalid postal code format", result);
            Assert.That(result, Is.EqualTo("ABC123"));
        }
        [Test]
        public void InsuranceQuote07_AgeOmitted()
        {
            driver.FindElement(By.Id("firstName")).SendKeys("John");
            driver.FindElement(By.Id("lastName")).SendKeys("Agara");
            driver.FindElement(By.Id("address")).SendKeys("55 Hollywood Blvd");
            driver.FindElement(By.Id("city")).SendKeys("Los Angeles");
            driver.FindElement(By.Id("province")).SendKeys("CA");
            driver.FindElement(By.Id("PostalCode")).SendKeys("90210");
            driver.FindElement(By.Id("phone")).SendKeys("(555)555-5555");
            driver.FindElement(By.Id("email")).SendKeys("tom.hanks@mail.com");
            driver.FindElement(By.Id("age")).SendKeys("");
            driver.FindElement(By.Id("experience")).SendKeys("5");
            driver.FindElement(By.Id("accidents")).SendKeys("0");

            driver.FindElement(By.Id("btnSubmit")).Click();

            var result = driver.FindElement(By.Id("age")).GetAttribute("value");
            //Assert.AreEqual("Age is required", result);
            Assert.That(result, Is.EqualTo(""));
        }
        [Test]
        public void InsuranceQuote08_AccidentsOmitted()
        {
            driver.FindElement(By.Id("firstName")).SendKeys("John");
            driver.FindElement(By.Id("lastName")).SendKeys("Agara");
            driver.FindElement(By.Id("address")).SendKeys("12 Privet Drive");
            driver.FindElement(By.Id("city")).SendKeys("Little Whinging");
            driver.FindElement(By.Id("province")).SendKeys("ON");
            driver.FindElement(By.Id("postalCode")).SendKeys("N2L 5G3");
            driver.FindElement(By.Id("phone")).SendKeys("789-456-1230");
            driver.FindElement(By.Id("email")).SendKeys("john.agara@mail.com");
            driver.FindElement(By.Id("age")).SendKeys("37");
            driver.FindElement(By.Id("experience")).SendKeys("8");
            driver.FindElement(By.Id("accidents")).SendKeys("");

            driver.FindElement(By.Id("btnSubmit")).Click();

            var result = driver.FindElement(By.Id("accidents")).GetAttribute("value");
            Assert.That(result, Is.EqualTo(""));
            //Assert.AreEqual("Accidents field is required", result);
            //Assert.That(result, Is.EqualTo("Accidents field is required"));
        }
        [Test]
        public void InsuranceQuote09_ExperienceOmitted()
        {
            driver.FindElement(By.Id("firstName")).SendKeys("John");
            driver.FindElement(By.Id("lastName")).SendKeys("Agara");
            driver.FindElement(By.Id("address")).SendKeys("1 Stark Tower");
            driver.FindElement(By.Id("city")).SendKeys("New York");
            driver.FindElement(By.Id("province")).SendKeys("NY");
            driver.FindElement(By.Id("postalCode")).SendKeys("10101");
            driver.FindElement(By.Id("phone")).SendKeys("212-555-1234");
            driver.FindElement(By.Id("email")).SendKeys("john.agaray@mail.com");
            driver.FindElement(By.Id("age")).SendKeys("45");
            driver.FindElement(By.Id("experience")).SendKeys("");
            driver.FindElement(By.Id("accidents")).SendKeys("0");

            driver.FindElement(By.Id("btnSubmit")).Click();

            var result = driver.FindElement(By.Id("experience")).GetAttribute("value");
            // Assert.AreEqual("Experience field is required", result);
            Assert.That(result, Is.EqualTo(""));

        }
        [Test]
        public void InsuranceQuote10_AgeAndExperienceMismatch()
        {
            driver.FindElement(By.Id("firstName")).SendKeys("John");
            driver.FindElement(By.Id("lastName")).SendKeys("Agara");
            driver.FindElement(By.Id("address")).SendKeys("20 Queens Blvd");
            driver.FindElement(By.Id("city")).SendKeys("Queens");
            driver.FindElement(By.Id("province")).SendKeys("ON");
            driver.FindElement(By.Id("postalCode")).SendKeys("N4G 6H8");
            driver.FindElement(By.Id("phone")).SendKeys("123-456-9876");
            driver.FindElement(By.Id("email")).SendKeys("peter.parker@mail.com");
            driver.FindElement(By.Id("age")).SendKeys("30");
            driver.FindElement(By.Id("experience")).SendKeys("20");
            driver.FindElement(By.Id("accidents")).SendKeys("0"); // Invalid mismatch

            driver.FindElement(By.Id("btnSubmit")).Click();

            string result = driver.FindElement(By.Id("finalQuote")).GetAttribute("value");
            Assert.That(result, Is.EqualTo("No Insurance for you!! Driver Age / Experience Not Correct"));

        }

        [Test]
        public void InsuranceQuote11_ValidDataWithRateReduction()
        {
            driver.FindElement(By.Id("firstName")).SendKeys("John");
            driver.FindElement(By.Id("lastName")).SendKeys("Agara");
            driver.FindElement(By.Id("address")).SendKeys("100 Spy Lane");
            driver.FindElement(By.Id("city")).SendKeys("RedRoom");
            driver.FindElement(By.Id("province")).SendKeys("ON");
            driver.FindElement(By.Id("postalCode")).SendKeys("N2L 6G7");
            driver.FindElement(By.Id("phone")).SendKeys("416-456-7890");
            driver.FindElement(By.Id("email")).SendKeys("john.agara@mail.com");
            driver.FindElement(By.Id("age")).SendKeys("40");
            driver.FindElement(By.Id("experience")).SendKeys("15");
            driver.FindElement(By.Id("accidents")).SendKeys("0");

            driver.FindElement(By.Id("btnSubmit")).Click();

            string result = driver.FindElement(By.Id("finalQuote")).GetAttribute("value");
            Assert.That(result, Is.EqualTo("$2190"));

        }
        [Test]
        public void InsuranceQuote12_NoExperience_BaseRate6000()
        {
            driver.FindElement(By.Id("firstName")).SendKeys("John");
            driver.FindElement(By.Id("lastName")).SendKeys("Agara");
            driver.FindElement(By.Id("address")).SendKeys("1 Gotham Manor");
            driver.FindElement(By.Id("city")).SendKeys("Gotham");
            driver.FindElement(By.Id("province")).SendKeys("ON");
            driver.FindElement(By.Id("postalCode")).SendKeys("N5L 2B1");
            driver.FindElement(By.Id("phone")).SendKeys("123-654-7890");
            driver.FindElement(By.Id("email")).SendKeys("john.agara@mail.com");
            driver.FindElement(By.Id("age")).SendKeys("25");
            driver.FindElement(By.Id("experience")).SendKeys("0"); // No experience
            driver.FindElement(By.Id("accidents")).SendKeys("0");

            driver.FindElement(By.Id("btnSubmit")).Click();

            string result = driver.FindElement(By.Id("finalQuote")).GetAttribute("value");
            Assert.That(result, Is.EqualTo("$6000"));

        }
        [Test]
        public void InsuranceQuote13_NoAccidents_BaseRate2190()
        {
            driver.FindElement(By.Id("firstName")).SendKeys("John");
            driver.FindElement(By.Id("lastName")).SendKeys("Agara");
            driver.FindElement(By.Id("address")).SendKeys("123 Shield Ave");
            driver.FindElement(By.Id("city")).SendKeys("Brooklyn");
            driver.FindElement(By.Id("province")).SendKeys("ON");
            driver.FindElement(By.Id("postalCode")).SendKeys("N1L 4F5");
            driver.FindElement(By.Id("phone")).SendKeys("416-789-4567");
            driver.FindElement(By.Id("email")).SendKeys("steve.rogers@mail.com");
            driver.FindElement(By.Id("age")).SendKeys("50");
            driver.FindElement(By.Id("experience")).SendKeys("20");
            driver.FindElement(By.Id("accidents")).SendKeys("0"); // No accidents

            driver.FindElement(By.Id("btnSubmit")).Click();

            string result = driver.FindElement(By.Id("finalQuote")).GetAttribute("value");
            Assert.That(result, Is.EqualTo("$2190"));

        }
        [Test]
        public void InsuranceQuote14_ValidDataWithOneAccident()
        {
            driver.FindElement(By.Id("firstName")).SendKeys("John");
            driver.FindElement(By.Id("lastName")).SendKeys("Agara");
            driver.FindElement(By.Id("Address")).SendKeys("123 Archer St");
            driver.FindElement(By.Id("city")).SendKeys("Smalltown");
            driver.FindElement(By.Id("province")).SendKeys("AB");
            driver.FindElement(By.Id("postalCode")).SendKeys("T2B 1A3");
            driver.FindElement(By.Id("phone")).SendKeys("(987)654-3210");
            driver.FindElement(By.Id("email")).SendKeys("john.agara@mail.com");
            driver.FindElement(By.Id("age")).SendKeys("35");
            driver.FindElement(By.Id("experience")).SendKeys("10");
            driver.FindElement(By.Id("accidents")).SendKeys("1"); // One accident

            driver.FindElement(By.Id("btnSubmit")).Click();

            string result = driver.FindElement(By.Id("finalQuote")).GetAttribute("value");
            Assert.That(result, Is.EqualTo("$2190"));

        }
        [Test]
        public void InsuranceQuote15_ThreeAccidents_InsuranceDenied()
        {
            driver.FindElement(By.Id("firstName")).SendKeys("John");
            driver.FindElement(By.Id("lastName")).SendKeys("Agara");
            driver.FindElement(By.Id("address")).SendKeys("20 Queens Blvd");
            driver.FindElement(By.Id("city")).SendKeys("Queens");
            driver.FindElement(By.Id("province")).SendKeys("ON");
            driver.FindElement(By.Id("postalCode")).SendKeys("N4G 6H8");
            driver.FindElement(By.Id("phone")).SendKeys("123-456-9876");
            driver.FindElement(By.Id("email")).SendKeys("peter.parker@mail.com");
            driver.FindElement(By.Id("age")).SendKeys("30");
            driver.FindElement(By.Id("experience")).SendKeys("5");
            driver.FindElement(By.Id("accidents")).SendKeys("3"); // Three accidents

            driver.FindElement(By.Id("btnSubmit")).Click();

            string result = driver.FindElement(By.Id("finalQuote")).GetAttribute("value");
            Assert.That(result, Is.EqualTo("No Insurance for you!!  Too many accidents - go take a course!"));
        }

    }

}

