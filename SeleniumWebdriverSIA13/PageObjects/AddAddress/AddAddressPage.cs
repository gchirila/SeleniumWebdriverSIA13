using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebdriverSIA13.PageObjects.AddAddress
{
    public class AddAddressPage
    {
        private IWebDriver _driver;

        public AddAddressPage(IWebDriver driver)
        {
            _driver = driver;
        }


        private IWebElement TxtFirstName => _driver.FindElement(By.Id("address_first_name"));

        private IWebElement TxtLastName => _driver.FindElement(By.CssSelector("input[name='address[last_name]']"));

        private IWebElement TxtAddress1 => _driver.FindElement(By.XPath("//input[@name='address[address1]']"));

        private IWebElement TxtCity => _driver.FindElement(By.Id("address_city"));

        private IWebElement TxtZipCode => _driver.FindElement(By.Id("address_zip_code"));

        private IWebElement BtnCreateAddress => _driver.FindElement(By.XPath("//input[@value='Create Address']"));

        public void AddAddress(string firstName, string lastName, string address1, string city, string zipcode)
        {
            TxtFirstName.SendKeys(firstName);
            TxtLastName.SendKeys(lastName);
            TxtAddress1.SendKeys(address1);
            TxtCity.SendKeys(city);
            TxtZipCode.SendKeys(zipcode);
            BtnCreateAddress.Click();
        }
    }
}
