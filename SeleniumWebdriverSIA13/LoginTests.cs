

using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

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
            driver.FindElement(By.Id("sign-in")).Click();
            //fill email
            Thread.Sleep(2000);
        }

        [TestMethod]
        public void UserShouldLoginSuccessfully()
        {
            loginPage.LoginApplication("test@test.test","test");
            var loggedInUserEmail = driver.FindElement(By.XPath("//span[@data-test='current-user']"));
            Assert.AreEqual("test@test.test", loggedInUserEmail.Text);
            Assert.IsTrue(loggedInUserEmail.Text.Equals("test@test.test"));
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
