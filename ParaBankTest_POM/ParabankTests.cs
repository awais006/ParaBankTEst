using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ParaBankTest_POM.PageObjectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParaBankTest_POM
{
    [TestClass]
    public class ParabankTests
    {
        string UserName = "test";
        string Password = "test123";

        [TestMethod]
        public void VerifySignup()
        {
            try
            {
                using (IWebDriver driver = new ChromeDriver())
                {
                    SignupPage signupPage = new SignupPage(driver);
                    signupPage.NavigateTo();

                    signupPage.GotoSignup();
                    signupPage.EnterFirstName("Test");
                    signupPage.EnterLastName("User");
                    signupPage.EnterStreet("1");
                    signupPage.EnterCity("Islamabad");
                    signupPage.EnterState("Federal");
                    signupPage.EnterZipCode("44000");
                    signupPage.EnterPhoneNumber("0333-1234567");
                    signupPage.EnterSSN("12345678");

                    signupPage.EnterUserName(UserName);
                    signupPage.EnterPassword(Password);
                    signupPage.EnterConfirmPassword(Password);

                    signupPage.ClickSignup();

                    string verifyPath = "//*[@id='rightPanel']/p";
                    IWebElement successTxt = driver.FindElement(By.XPath(verifyPath));

                    Assert.AreEqual("Your account was created successfully. You are now logged in.", successTxt.Text);
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.ToString());
                Console.ReadLine();
            }
        }

        [TestMethod]
        public void VerifyCorrectLogin()
        {
            try
            {
                using (IWebDriver driver = new ChromeDriver())
                {
                    var loginPage = new LoginPage(driver);
                    loginPage.NavigateTo();

                    loginPage.EnterUserName(UserName);
                    loginPage.EnterPassword(Password);

                    loginPage.ClickLogin();

                    string verifyPath = "//div[@id='leftPanel']/p[@class='smallText']/b";
                    IWebElement welcomeTxt = driver.FindElement(By.XPath(verifyPath));

                    Assert.AreEqual("Welcome", welcomeTxt.Text);
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.ToString());
                Console.ReadLine();
            }
        }

        [TestMethod]
        public void VerifyInCorrectLogin()
        {
            try
            {
                using (IWebDriver driver = new ChromeDriver())
                {
                    var loginPage = new LoginPage(driver);
                    loginPage.NavigateTo();

                    loginPage.EnterUserName(UserName);
                    loginPage.EnterPassword("testabc");

                    loginPage.ClickLogin();

                    string verifyPath = "//div[@id='rightPanel']/h1";
                    IWebElement errorTxt = driver.FindElement(By.XPath(verifyPath));

                    Assert.AreEqual("Error!", errorTxt.Text);
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.ToString());
                Console.ReadLine();
            }
        }

    }
}
