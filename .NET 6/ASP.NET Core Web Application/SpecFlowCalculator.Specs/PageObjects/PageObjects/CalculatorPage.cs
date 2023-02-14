using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SpecFlow.Actions.Selenium;
using System;

namespace SpecFlowCalculator.Specs.PageObjects
{
    public class CalculatorPage
    {
        private readonly IBrowserInteractions _browserInteractions;
        private readonly IWebDriver _webDriver;
        private readonly WebDriverWait wait;

        //The default wait time in seconds for wait.Until
        public const int DefaultWaitInSeconds = 5;

        private const string PageUrl = "https://www.saucedemo.com/";

        private IWebElement UserName => _browserInteractions.WaitAndReturnElement(By.Id("user-name"));

        private IWebElement Password => _browserInteractions.WaitAndReturnElement(By.Id("password"));

        private IWebElement LoginButton => _browserInteractions.WaitAndReturnElement(By.Id("login-button"));

        //private IWebElement SubtractButton => _browserInteractions.WaitAndReturnElement(By.Id("subtract"));

        //private IWebElement MultiplyButton => _browserInteractions.WaitAndReturnElement(By.Id("multiply"));

       //private IWebElement DivideButton => _browserInteractions.WaitAndReturnElement(By.Id("divide"));

        //private IWebElement Result => _browserInteractions.WaitAndReturnElement(By.Id("result"));

        public CalculatorPage(IBrowserInteractions browserInteractions)
        {
            _browserInteractions = browserInteractions;
           _webDriver = new ChromeDriver();
            wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(DefaultWaitInSeconds));
        }

        public void Goto()
        {
            _browserInteractions.GoToUrl(PageUrl);
        }

        public void EnterUsername(string username)
        {
            UserName.SendKeysWithClear(username); // might need to change function no reason for clear
        }

        public void EnterPassword(string username)
        {
            Password.SendKeysWithClear(username);  // might need to change function no reason for clear
        }
        public void WaitForURLChange()
        {
   

            wait.Until(d => !d.Url.Equals(PageUrl));
        }
        public bool WaitForErrorMessage()
        {
            
            IWebElement parentElement = _webDriver.FindElement(By.ClassName("error-message-container"));

            wait.Until(d => parentElement.FindElements(By.TagName("h3")).Count > 0);

            bool ErrorElementExists = parentElement.FindElements(By.TagName("h3")).Count > 0;

            return ErrorElementExists;
        }

        public void ClickLogin()
        {
            LoginButton.ClickWithRetry();
        }


        public string CurrentURL()
        {
            string CurrentUrl = _browserInteractions.GetUrl();
            return CurrentUrl;
            //return Result.HasValue(result);
        }
        /// <summary>
        /// Helper method to wait until the expected result is available on the UI
        /// </summary>
        /// <typeparam name="T">The type of result to retrieve</typeparam>
        /// <param name="getResult">The function to poll the result from the UI</param>
        /// <param name="isResultAccepted">The function to decide if the polled result is accepted</param>
        /// <returns>An accepted result returned from the UI. If the UI does not return an accepted result within the timeout an exception is thrown.</returns>
        
    }
}
