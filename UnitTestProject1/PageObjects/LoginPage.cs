using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.PageObjects
{
    class LoginPage
    {

    public LoginPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = ("//input[@autocomplete='username']"))]
        public IWebElement userName;

        [FindsBy(How = How.Id, Using = "login-signin")]
        public IWebElement SigInButton;

        [FindsBy(How = How.Id, Using = "login-passwd")]
        public IWebElement loginPasswd;

        [FindsBy(How = How.Id, Using = "oauth2-agree")]
        public IWebElement oauth2Agree;


        public void logIn(string username, string password)
        {
            userName.SendKeys(username);
            SigInButton.Click();
            loginPasswd.SendKeys(password);
            SigInButton.Click();
            oauth2Agree.Click();
        }

    }

}
