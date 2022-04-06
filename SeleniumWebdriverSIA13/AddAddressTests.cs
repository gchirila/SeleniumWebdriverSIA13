using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumWebdriverSIA13.PageObjects.AddAddress;
using SeleniumWebdriverSIA13.PageObjects.AddressesPage;
using SeleniumWebdriverSIA13.PageObjects.HomePage;
using SeleniumWebdriverSIA13.PageObjects.LoginPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumWebdriverSIA13
{
    [TestClass]
    public class AddAddressTests
    {
        private IWebDriver _driver;
        private AddAddressPage addAddressPage;

        [TestInitialize]
        public void TestInitialize()
        {
            _driver = new ChromeDriver();
            //maximize the page
            _driver.Manage().Window.Maximize();
            //open the application url
            _driver.Navigate().GoToUrl("http://a.testaddressbook.com/");
            //click sign in button from the menu
            _driver.FindElement(By.Id("sign-in")).Click();
            //fill email
            Thread.Sleep(2000);
            var loginPage = new LoginPage(_driver);
            loginPage.LoginApplication("test@test.test", "test");
            var homePage = new HomePage(_driver);
            homePage.NavigateToAddressesPage();
            var addressesPage = new AddressesPage(_driver);
            Thread.Sleep(2000);
            addAddressPage = addressesPage.NavigateToAddAddressPage();
            Thread.Sleep(2000);
        }

        [TestMethod]
        public void ShouldAddAddressSuccessfully()
        {
            addAddressPage.AddAddress("SIA13 FN", "SIA13 LN", "SIA13 address1", "SIA13 city", "SIA13 zipcode");
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _driver.Quit();
        }
    }
}
