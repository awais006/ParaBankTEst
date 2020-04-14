using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParaBankTest_POM.PageObjectModels
{
    class LoginPage
    {
        private readonly IWebDriver Driver;
        private const string PageUrl = "https://parabank.parasoft.com/parabank/index.htm";
        private const string PageTitle = "ParaBank | Welcome | Online Banking";

        public LoginPage(IWebDriver driver)
        {
            Driver = driver;
        }

        public void EnterUserName(string userName) => Driver.FindElement(By.Name("username")).SendKeys(userName);

        public void EnterPassword(string password) => Driver.FindElement(By.Name("password")).SendKeys(password);

        public void ClickLogin() => Driver.FindElement(By.XPath("//form[@name='login']/div[@class='login']/input[@class='button']")).Click();

        public void NavigateTo()
        {
            Driver.Navigate().GoToUrl(PageUrl);
            EnsurePageLoaded();
        }

        public void EnsurePageLoaded()
        {
            bool pageHasLoaded = (Driver.Url == PageUrl) && (Driver.Title == PageTitle );
            if (!pageHasLoaded)
                throw new Exception($"Failed to load page. Page URL = '{Driver.Url}' Page Source: \r\n '{Driver.PageSource}'");
        }

    }
}
