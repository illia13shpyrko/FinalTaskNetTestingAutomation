using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;

namespace FinalTask.Net_Testing_Automation
{
    public class UC_3_Edge
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            // WebDriver Instantiation for Edge
            EdgeOptions options = new EdgeOptions();

            driver = new EdgeDriver(options);
            driver.Manage().Window.Maximize();
            Console.WriteLine("Test Setup: Launching Edge WebDriver");
        }

        [Test]
        public void UC_3E()
        {
            try
            {
                // Test Start
                Console.WriteLine("Test Started: Login with Valid Credentials");

                // Webpage Navigation
                driver.Navigate().GoToUrl("https://www.saucedemo.com/");
                Console.WriteLine("Navigating to SauceDemo login page");

                    // Asserting the link is correct
                    Assert.That(driver.Url, Is.EqualTo("https://www.saucedemo.com/"));

                // Elements identification
                var username = driver.FindElement(By.CssSelector("#user-name"));
                Console.WriteLine("Finding username input field");
                var password = driver.FindElement(By.CssSelector("#password"));
                Console.WriteLine("Finding password input field");
                var loginButton = driver.FindElement(By.CssSelector("#login-button"));
                Console.WriteLine("Finding login button");

                    // Asserting the login button is displayed on the page
                    Assert.True(loginButton.Displayed);

                // Passing valid credentials
                username.SendKeys($"standard_user");
                Console.WriteLine($"Entering username: standard_user (valid)");
                password.SendKeys("secret_sauce");
                Console.WriteLine("Entering password: secret_sauce (valid)");

                // Clicking login button
                loginButton.Submit();
                Console.WriteLine("Clicking login button");

                // Checking title name on the page
                var title = driver.FindElement(By.ClassName("app_logo")).Text;
                Console.WriteLine("Retrieving page title");

                    // Asserting the title name is right
                    Assert.That(title, Is.EqualTo("Swag Labs"));
                    Console.WriteLine("Verifying page title: Swag Labs");

                    //Asserting the inventory page is displayed
                    Assert.That(driver.Url, Is.EqualTo("https://www.saucedemo.com/inventory.html"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                // Finishing the session
                driver.Quit();
                Console.WriteLine("Test Teardown: Closing Edge WebDriver");
            }
        }

        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }
    }
}