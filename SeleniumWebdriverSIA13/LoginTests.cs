

using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumWebdriverSIA13.PageObjects.LoginPage;
using System.Threading;
using SeleniumWebdriverSIA13.PageObjects.Shared;

namespace SeleniumWebdriverSIA13
{
    [TestClass]
    public class LoginTests
    {

        private IWebDriver driver;
        private LoginPage loginPage;

        [TestInitialize]
        public void TestSetup()
        {
            driver = new ChromeDriver();
            //maximize the page
            driver.Manage().Window.Maximize();
            //open the application url
            driver.Navigate().GoToUrl("http://a.testaddressbook.com/");
            //click sign in button from the menu
            var menuItemControl = new MenuItemControlLoggedOut(driver);
            menuItemControl.NavigateToLoginPage();
            //fill email
            loginPage = new LoginPage(driver);
        }

        [TestMethod]
        public void UserShouldLoginSuccessfully()
        {
            loginPage.LoginApplication("test@test.test","test");
            var menuItemControl = new MenuItemControlLoggedIn(driver);
            var loggedInUserEmail = menuItemControl.UserEmail;
            Assert.AreEqual("test@test.test", loggedInUserEmail);
            Assert.IsTrue(loggedInUserEmail.Equals("test@test.test"));
        }

        [TestMethod]
        public void UserShouldNotLoginWithInvalidEmail()
        {
            loginPage.LoginApplication("invalidEmal@test.test", "test");
            //verify/assert that the user cannot login
            var badEmailOrPassword = driver.FindElement(By.XPath("//div[@data-test='notice']"));
            Assert.AreEqual("Bad email or password.", badEmailOrPassword.Text);
            Assert.IsTrue(badEmailOrPassword.Text.Equals("Bad email or password."));
        }

        [TestMethod]
        public void UserShouldNotLoginWithInvalidPassword()
        {
            loginPage.LoginApplication("test@test.test", "invalidPassword");
            //verify/assert that the user cannot login
            var badEmailOrPassword = driver.FindElement(By.XPath("//div[@data-test='notice']"));
            Assert.AreEqual("Bad email or password.", badEmailOrPassword.Text);
            Assert.IsTrue(badEmailOrPassword.Text.Equals("Bad email or password."));
        }

        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }

    }
}
