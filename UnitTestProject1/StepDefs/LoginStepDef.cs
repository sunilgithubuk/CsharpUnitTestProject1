using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Configuration;
using TechTalk.SpecFlow;
using UnitTestProject1.PageObjects;
using UnitTestProject1.Utilities;

namespace UnitTestProject1
{
    [Binding]
    public class LoginStepDef
    {
        public IWebDriver driver = BaseClass.getDriver();
        HomePage homePage;
        LoginPage loginPage;
        public LoginStepDef()
        {
            homePage = new HomePage(driver);
            loginPage = new LoginPage(driver);
        }
        [Given(@"user is on homepage")]
        public void OpenHomePage()
        {
           var url = ConfigurationManager.AppSettings.Get("url");
            driver.Navigate().GoToUrl(url);

        }
        [When(@"login with valid credentials")]
        public void WhenLoginWithValidCredentials()
        {
            homePage.login.Click();
            loginPage.logIn(ConfigurationManager.AppSettings.Get("yahooUserName"), ConfigurationManager.AppSettings.Get("yahooPassword"));
            Console.WriteLine("user is logged in" + homePage.logOut.Displayed);
        }

        [Then(@"user is successfully logged in")]
        public void ThenUserIsSuccessfullyLoggedIn()
        {
            Assert.IsTrue(homePage.logOut.Displayed);
            driver.Quit();
        }

    }
}
