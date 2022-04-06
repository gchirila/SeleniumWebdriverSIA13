

using OpenQA.Selenium;

namespace SeleniumWebdriverSIA13.PageObjects.HomePage
{
    public class HomePage
    {
        private IWebDriver _driver;

        public HomePage(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement BtnAddresses => _driver.FindElement(By.CssSelector("a[data-test=addresses]"));
    
    
        public void NavigateToAddressesPage()
        {
            BtnAddresses.Click();
        }
    }
}
