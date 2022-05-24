using OpenQA.Selenium;

namespace SeleniumWebdriverSIA13.PageObjects.Shared
{
    public class MenuItemControlCommon
    {
        public IWebDriver _driver;

        public MenuItemControlCommon(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement BtnHome => _driver.FindElement(By.CssSelector(""));
    }
}