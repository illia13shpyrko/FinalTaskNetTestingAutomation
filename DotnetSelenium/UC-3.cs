using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace FinalTask_.Net_Testing_Automation
{
    public class UC3
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            // WebDriver Instantiation
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            Console.WriteLine("Test Setup: Launching Chrome WebDriver");
        }

        [Test]
        public void UC_3()
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

                // Passing valid values to the fields
                username.SendKeys("standard_user");
                Console.WriteLine("Entering username: standard_user (valid)");
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
