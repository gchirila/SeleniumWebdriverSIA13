using OpenQA.Selenium;
using System.Threading;
using SeleniumWebdriverSIA13.Helpers;

namespace SeleniumWebdriverSIA13.PageObjects.LoginPage
{
    public class LoginPage
    {
        private IWebDriver driver;

        public LoginPage(IWebDriver _driver)
        {
            driver = _driver;
        }

        private By Email = By.Id("session_email");
        private IWebElement TxtEmail => driver.FindElement(Email);

        private IWebElement TxtPassword => driver.FindElement(By.Name("session[password]"));

        private IWebElement BtnLogin => driver.FindElement(By.CssSelector("input[value='Sign in']"));

        public IWebElement LblBadEmailOrPassword => driver.FindElement(By.XPath(""));


        public HomePage.HomePage LoginApplication(string email, string password)
        {
            driver.WaitForElement(Email);
            TxtEmail.SendKeys(email);
            TxtPassword.SendKeys(password);
            BtnLogin.Click();
            return new HomePage.HomePage(driver);
        }
    }
}
