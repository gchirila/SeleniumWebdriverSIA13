using OpenQA.Selenium;
using SeleniumWebdriverSIA13.PageObjects.AddAddress;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebdriverSIA13.PageObjects.AddressesPage
{
    public class AddressesPage
    {
        private IWebDriver _driver;

        public AddressesPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement BtnNewAddress => _driver.FindElement(By.CssSelector("a[data-test=create]"));

        public AddAddressPage NavigateToAddAddressPage()
        {
            BtnNewAddress.Click();
            return new AddAddressPage(_driver);
        }
    }
}
