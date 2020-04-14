using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParaBankTest_POM.PageObjectModels
{
    class SignupPage
    {
        private readonly IWebDriver Driver;
        private const string PageUrl = "https://parabank.parasoft.com/parabank/register.htm";
        private const string PageTitle = "ParaBank | Register for Free Online Account Access";

        public SignupPage(IWebDriver driver)
        {
            Driver = driver;
        }

        public void GotoSignup() => Driver.FindElement(By.XPath("//*[@id='loginPanel']/p[2]/a")).Click();

        public void EnterFirstName(string Firstname) => Driver.FindElement(By.Id("customer.firstName")).SendKeys(Firstname);
        public void EnterLastName(string Lastname) => Driver.FindElement(By.Id("customer.lastName")).SendKeys(Lastname);
        public void EnterStreet(string Street) => Driver.FindElement(By.Id("customer.address.street")).SendKeys(Street);
        public void EnterCity(string City) => Driver.FindElement(By.Id("customer.address.city")).SendKeys(City);
        public void EnterState(string State) => Driver.FindElement(By.Id("customer.address.state")).SendKeys(State);
        public void EnterZipCode(string ZipCode) => Driver.FindElement(By.Id("customer.address.zipCode")).SendKeys(ZipCode);
        public void EnterPhoneNumber(string PhoneNumber) => Driver.FindElement(By.Id("customer.phoneNumber")).SendKeys(PhoneNumber);
        public void EnterSSN(string SSN) => Driver.FindElement(By.Id("customer.ssn")).SendKeys(SSN);

        public void EnterUserName(string UserName) => Driver.FindElement(By.Id("customer.username")).SendKeys(UserName);
        public void EnterPassword(string Password) => Driver.FindElement(By.Id("customer.password")).SendKeys(Password);
        public void EnterConfirmPassword(string Password) => Driver.FindElement(By.Id("repeatedPassword")).SendKeys(Password);

        public void ClickSignup() => Driver.FindElement(By.XPath("//*[@id='customerForm']/table/tbody/tr[13]/td[2]/input")).Click();

        public void NavigateTo()
        {
            Driver.Navigate().GoToUrl(PageUrl);
            EnsurePageLoaded();
        }

        public void EnsurePageLoaded()
        {
            bool pageHasLoaded = (Driver.Url == PageUrl) && (Driver.Title == PageTitle);
            if (!pageHasLoaded)
                throw new Exception($"Failed to load page. Page URL = '{Driver.Url}' Page Source: \r\n '{Driver.PageSource}'");
        }

    }
}
