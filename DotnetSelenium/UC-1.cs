using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace DotnetSelenium
{
    public class Tests
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void UC_1()
        {
            try
            {
                driver.Navigate().GoToUrl("https://www.saucedemo.com/");
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));

                var username = driver.FindElement(By.CssSelector("#user-name"));
                var password = driver.FindElement(By.CssSelector("#password"));
                var loginButton = driver.FindElement(By.CssSelector("#login-button"));

                username.SendKeys("username7891");
                password.SendKeys("password1234");

                wait.Until(driver => true);

                username.SendKeys(Keys.Control + "a");
                username.SendKeys(Keys.Delete);

                password.SendKeys(Keys.Control + "a");
                password.SendKeys(Keys.Delete);

                loginButton.Click();

                IWebElement errorMessageElement = driver.FindElement(By.XPath("//*[@id=\"login_button_container\"]/div/form/div[3]/h3"));
                string errorMessage = errorMessageElement.Text;

                Assert.That(errorMessage, Is.EqualTo("Epic sadface: Username is required"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                driver.Quit();
            }
        }

        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }
    }
}