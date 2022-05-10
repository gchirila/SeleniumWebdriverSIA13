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

        private IList<IWebElement> LstAddresses =>
            _driver.FindElements(By.CssSelector("tbody tr"));

        private IWebElement BtnEdit(string addressName) =>
            LstAddresses.FirstOrDefault(element => element.Text.Contains(addressName))
                .FindElement(By.CssSelector("a[data-test*=edit]"));

        private IWebElement BtnDelete(string addressName) =>
            LstAddresses.FirstOrDefault(element => element.Text.Contains(addressName))
                .FindElement(By.CssSelector("a[data-method=delete]"));

        private IWebElement BtnNewAddress => 
            _driver.FindElement(By.CssSelector("a[data-test=create]"));

        public AddAddressPage NavigateToAddAddressPage()
        {
            BtnNewAddress.Click();
            return new AddAddressPage(_driver);
        }

        public AddAddressPage NavigateToEditAddressPage(string addressName)
        {
            BtnEdit(addressName).Click();
            return new AddAddressPage(_driver);
        }

        public void DeleteAddress(string addressName)
        {
            BtnDelete(addressName).Click();
            _driver.SwitchTo().Alert().Dismiss();
        }
    }
}
