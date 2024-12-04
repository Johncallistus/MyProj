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
        

    }

}

