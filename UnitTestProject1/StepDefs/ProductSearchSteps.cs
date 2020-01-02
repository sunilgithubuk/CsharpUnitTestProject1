using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Configuration;
using System.Threading;
using TechTalk.SpecFlow;
using UnitTestProject1.PageObjects;
using UnitTestProject1.Utilities;

namespace UnitTestProject1.StepDefs
{
    [Binding]
    public class ProductSearchSteps
    {
        public IWebDriver driver = BaseClass.getDriver();
        HomePage homePage;
        LoginPage loginPage;

        public ProductSearchSteps()
        {
            homePage = new HomePage(driver);
            loginPage = new LoginPage(driver);
        }
        [Given(@"user is logged in")]
        public void GivenUserIsLoggedIn()
        {
            driver.Navigate().GoToUrl(ConfigurationManager.AppSettings.Get("url"));
            homePage.login.Click();
            loginPage.logIn(ConfigurationManager.AppSettings.Get("yahooUserName"), ConfigurationManager.AppSettings.Get("yahooPassword"));
            Assert.IsTrue(homePage.logOut.Displayed);

        }

        [When(@"search for a product")]
        public void WhenSearchForAProduct()
        {
            homePage.search.SendKeys("Jack Daniels Tennessee Whiskey" + System.Environment.NewLine);
        }
        
        [Then(@"result page displayed the searched product")]
        public void ThenResultPageDisplayedTheSearchedProduct()
        {
            Console.WriteLine("searched product is displayed " +driver.FindElement(By.PartialLinkText("Jack Daniels Tennessee Whiskey")).Displayed);
            Assert.IsTrue(driver.FindElement(By.PartialLinkText("Jack Daniels Tennessee Whiskey")).Displayed);
            driver.Quit();
        }
    }
}
