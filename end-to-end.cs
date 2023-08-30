using OpenQA.Selenium;

namespace PageObjectModelExample
{
    public class LoginPage
    {
        private IWebDriver _driver;
        
        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public readonly By _usernameInput = By.Id("username");
        public readonly By _passwordInput = By.Id("password");
        public readonly By _submitButton = By.Id("submit");
        
        public IWebElement UsernameInput => _driver.FindElement(_usernameInput);
        public IWebElement PasswordInput => _driver.FindElement(_passwordInput);
        public IWebElement SubmitButton => _driver.FindElement(_submitButton);
        
        public void Login(string username, string password)
        {
            UsernameInput.SendKeys(username);
            PasswordInput.SendKeys(password);
            SubmitButton.Click();
        }
    }
}

using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace PageObjectModelExample.Tests
{
    [TestFixture]
    public class LoginTests
    {
        private IWebDriver _driver;
        private LoginPage _loginPage;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver(); // You can use other browser drivers as well
            _driver.Navigate().GoToUrl("your_login_page_url");
            
            _loginPage = new LoginPage(_driver);
        }

        [Test]
        public void SuccessfulLoginTest()
        {
            string username = "your_username";
            string password = "your_password";

            _loginPage.Login(username, password);

            // Add assertions for successful login
            Assert.IsTrue(/* Check for successful login condition */);
        }

        [TearDown]
        public void Teardown()
        {
            _driver.Quit();
        }
    }
}
