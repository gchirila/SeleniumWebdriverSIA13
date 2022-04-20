using OpenQA.Selenium;

namespace SeleniumWebdriverSIA13.PageObjects.AddressDetails
{
    public class AddressDetailsPage
    {
        private IWebDriver _driver;

        public AddressDetailsPage(IWebDriver browser)
        {
            _driver = browser;
        }

        private IWebElement LblNotice => _driver.FindElement(By.CssSelector("div[data-test=notice]"));


        public string NoticeText => LblNotice.Text;
    }
}