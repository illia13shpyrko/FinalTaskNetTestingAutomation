using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace DotnetSelenium
{
    public class UC2
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            Console.WriteLine("Test Setup: Launching Chrome WebDriver");
        }

        [Test]
        public void UC_2()
        {
            try
            {
                Console.WriteLine("Test Started: Login with Valid Credentials");

                // Webpage Navigation
                driver.Navigate().GoToUrl("https://www.saucedemo.com/");
                Console.WriteLine("Navigating to SauceDemo login page");

                // Elements identification
                var username = driver.FindElement(By.CssSelector("#user-name"));
                Console.WriteLine("Finding username input field");
                var password = driver.FindElement(By.CssSelector("#password"));
                Console.WriteLine("Finding password input field");
                var loginButton = driver.FindElement(By.CssSelector("#login-button"));
                Console.WriteLine("Finding login button");

                // Passing invalid values to the fields
                username.SendKeys("username7891");
                Console.WriteLine("Entering username: username7891 (invalid)");
                password.SendKeys("password1234");
                Console.WriteLine("Entering password: password1234 (invalid)");

                // Clearing the password field
                password.SendKeys(Keys.Control + "a");
                password.SendKeys(Keys.Delete);
                Console.WriteLine("Clearing password field");

                // Clicking login button
                loginButton.Submit();
                Console.WriteLine("Clicking login button");

                // Identifying the error message
                IWebElement errorMessageElement = driver.FindElement(By.XPath("//*[@id=\"login_button_container\"]/div/form/div[3]/h3"));
                string errorMessage = errorMessageElement.Text;
                Console.WriteLine("Identifying the error message - Password is required");

                // Validating the error message
                Assert.That(errorMessage, Is.EqualTo("Epic sadface: Password is required"));
                Console.WriteLine("Validating the error message - Password is required");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                // Finishing the session
                driver.Quit();
                Console.WriteLine("Test Teardown: Closing Chrome WebDriver");
            }
        }

        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }
    }
}
