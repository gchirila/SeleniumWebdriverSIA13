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
using SeleniumWebdriverSIA13.PageObjects.AddAddress.InputData;

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
            var homePage = loginPage.LoginApplication("test@test.test", "test");
            var addressesPage = homePage.NavigateToAddressesPage();
            Thread.Sleep(2000);
            addAddressPage = addressesPage.NavigateToAddAddressPage();
            Thread.Sleep(2000);
        }

        [TestMethod]
        public void ShouldAddAddressSuccessfully()
        {
            var inputData = new AddAddressPageBO()
            {
                //FirstName = "SIA13 FN",
                LastName = "SIA13 LN",
                Address1 = "SIA13 address1",
                City = "SIA13 city",
                State = "California",
                ZipCode = "SIA13 zipcode",
                Country = "Canada",
                Color = "#FF0000"
            };
            var addressDetailsPage = addAddressPage.AddAddress(inputData);
            Assert.AreEqual("Address was successfully created.", addressDetailsPage.NoticeText);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _driver.Quit();
        }
    }
}
