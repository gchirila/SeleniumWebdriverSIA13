using OpenQA.Selenium;

namespace SeleniumWebdriverSIA13.PageObjects.Shared
{
    public class MenuItemControlLoggedIn: MenuItemControlCommon
    {
        public MenuItemControlLoggedIn(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement BtnSignOut =>
            _driver.FindElement(By.Id("sign-out"));

        private IWebElement BtnAddresses =>
            _driver.FindElement(By.CssSelector("a[data-test=addresses]"));

        private IWebElement LblUserEmail =>
            _driver.FindElement(By.CssSelector("span[data-test=current-user]"));


        public AddressesPage.AddressesPage NavigateToAddressesPage()
        {
            BtnAddresses.Click();
            return new AddressesPage.AddressesPage(_driver);
        }

        public string UserEmail => LblUserEmail.Text;
    }
}