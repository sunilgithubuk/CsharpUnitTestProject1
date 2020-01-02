using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.PageObjects
{
    class HomePage
    {
   
        public HomePage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath, Using =("//*[@data-synthetics='login-button']"))]
        public IWebElement login;

        [FindsBy(How = How.XPath, Using = ("//a[@data-test='logout-button']"))]
        public IWebElement logOut;
        [FindsBy(How = How.Id, Using = "search")]
        public IWebElement search;
        
    }
}
