using OpenQA.Selenium;
using SeleniumWebdriverSIA13.Helpers;

namespace SeleniumWebdriverSIA13.PageObjects.Shared
{
    public class MenuItemControlLoggedOut: MenuItemControlCommon
    {
        public MenuItemControlLoggedOut(IWebDriver driver) : base(driver)
        {
        }

        private By SignIn = By.Id("sign-in");
        private IWebElement BtnSignIn =>
            _driver.FindElement(SignIn);

        public LoginPage.LoginPage NavigateToLoginPage()
        {
            _driver.WaitForElement(SignIn);
            BtnSignIn.Click();
            return new LoginPage.LoginPage(_driver);
        }
    }
}