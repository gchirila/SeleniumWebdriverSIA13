

using OpenQA.Selenium;
using SeleniumWebdriverSIA13.PageObjects.Shared;

namespace SeleniumWebdriverSIA13.PageObjects.HomePage
{
    public class HomePage
    {
        private IWebDriver _driver;

        public HomePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public MenuItemControlLoggedIn menuItemControl => 
            new MenuItemControlLoggedIn(_driver);
    }
}
