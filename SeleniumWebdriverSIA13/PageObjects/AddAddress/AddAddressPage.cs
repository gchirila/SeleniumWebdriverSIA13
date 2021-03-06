using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using SeleniumWebdriverSIA13.Helpers;
using SeleniumWebdriverSIA13.PageObjects.AddAddress.InputData;
using SeleniumWebdriverSIA13.PageObjects.AddressDetails;

namespace SeleniumWebdriverSIA13.PageObjects.AddAddress
{
    public class AddAddressPage
    {
        private IWebDriver _driver;

        public AddAddressPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private By FirstName = By.Id("address_first_name");
        private IWebElement TxtFirstName => 
            _driver.FindElement(FirstName);

        private IWebElement TxtLastName => _driver.FindElement(By.CssSelector("input[name='address[last_name]']"));

        private IWebElement TxtAddress1 => _driver.FindElement(By.XPath("//input[@name='address[address1]']"));

        private IWebElement TxtCity => _driver.FindElement(By.Id("address_city"));

        private IWebElement DdlStates => _driver.FindElement(By.Id("address_state"));

        private IWebElement TxtZipCode => _driver.FindElement(By.Id("address_zip_code"));

        private IList<IWebElement> LstCountries => _driver.FindElements(By.CssSelector("label[for^=address_country]"));

        private IWebElement TxtColor => _driver.FindElement(By.Id("address_color"));

        private IWebElement BtnSubmit => _driver.FindElement(By.XPath("//input[@data-test='submit']"));

        public AddressDetailsPage AddAddress(AddAddressPageBO inputData)
        {
            _driver.WaitForElement(FirstName);
            TxtFirstName.Clear();
            TxtFirstName.SendKeys(inputData.FirstName);
            TxtLastName.Clear();
            TxtLastName.SendKeys(inputData.LastName);
            TxtAddress1.SendKeys($"{Keys.Control}A{Keys.Delete}");
            TxtAddress1.SendKeys(inputData.Address1);
            TxtCity.SendKeys(inputData.City);

            var state = new SelectElement(DdlStates);
            state.SelectByText(inputData.State);

            TxtZipCode.SendKeys(inputData.ZipCode);

            LstCountries[0].Click();

            LstCountries.FirstOrDefault(element => element.Text.Contains(inputData.Country)).Click();

            var jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].setAttribute('value', arguments[1])", TxtColor, inputData.Color);
            BtnSubmit.Click();
            return new AddressDetailsPage(_driver);
        }
    }
}
