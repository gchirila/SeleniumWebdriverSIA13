using OpenQA.Selenium;
using System.Threading;

namespace SeleniumWebdriverSIA13
{
    public class LoginPage
    {
        private IWebDriver driver;

        public LoginPage(IWebDriver _driver)
        {
            driver = _driver;
        }

        private IWebElement TxtEmail => driver.FindElement(By.Id("session_email"));

        private IWebElement TxtPassword => driver.FindElement(By.Name("session[password]"));

        private IWebElement BtnLogin => driver.FindElement(By.CssSelector("input[value='Sign in']"));

        public IWebElement LblBadEmailOrPassword => driver.FindElement(By.XPath(""));


        public void LoginApplication(string email, string password)
        {
            TxtEmail.SendKeys(email);
            TxtPassword.SendKeys(password);
            BtnLogin.Click();
            Thread.Sleep(2000);
        }
    }
}
