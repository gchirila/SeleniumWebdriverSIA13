using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace SeleniumWebdriverSIA13
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void UserShouldLoginSuccessfully()
        {
            //open the browser
            var driver = new ChromeDriver();
            //maximize the page
            driver.Manage().Window.Maximize();
            //open the application url
            driver.Navigate().GoToUrl("http://a.testaddressbook.com/");
            //click sign in button from the menu
            driver.FindElement(By.Id("sign-in")).Click();
            //fill email
            Thread.Sleep(2000);
            var email = driver.FindElement(By.Id("session_email"));
            email.SendKeys("test@test.test");
            //fill password
            var password = driver.FindElement(By.Name("session[password]"));
            password.SendKeys("test");
            //click login button
            var loginButton = driver.FindElement(By.CssSelector("input[value='Sign in']"));
            loginButton.Click();
            Thread.Sleep(2000);
            //verify/assert that the user email is the correct one
            var loggedInUserEmail = driver.FindElement(By.XPath("//span[@data-test='current-user']"));
            var userEmail = loggedInUserEmail.Text;
            Assert.AreEqual("test@test.test", loggedInUserEmail.Text);
            Assert.IsTrue(loggedInUserEmail.Text.Equals("test@test.test"));
            //Close/Quit the browser
            driver.Quit();
        }
    }
}
