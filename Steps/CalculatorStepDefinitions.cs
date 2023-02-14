using FluentAssertions;
using OpenQA.Selenium;
using SpecFlowCalculator.Specs.PageObjects;
using System;
using TechTalk.SpecFlow;
using static System.Net.WebRequestMethods;

namespace SpecFlowCalculator.Specs.Steps
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {
        private readonly CalculatorPage _calculatorPage;

        public CalculatorStepDefinitions(CalculatorPage calculatorPage)
        {
            _calculatorPage = calculatorPage;
        }

        [Given("the username is (.*)")]
        public void GivenTheUsernameIs(string username)
        {
            _calculatorPage.EnterUsername(username);
        }

        [Given("the password is (.*)")]
        public void GivenTheSecondNumberIs(string password)
        {
            _calculatorPage.EnterPassword(password);
        }

        [When("User clicks login button")]
        public void WhenUserClicksLoginButton()
        {
            _calculatorPage.ClickLogin();
        }

        /*[When("the two numbers are subtracted")]
        public void WhenTheTwoNumbersAreSubtracted()
        {
            _calculatorPage.ClickSubtract();
        }

        [When("the two numbers are multiplied")]
        public void WhenTheTwoNumbersAreMultiplied()
        {
            _calculatorPage.ClickMultiply();
        }

        [When("the two numbers are divided")]
        public void WhenTheTwoNumbersAreDivided()
        {
            _calculatorPage.ClickDivide();
        }*/

        [Then("User is sent to Home Page")]
        public void ThenUserIsSentToHomePage()
        {
            //delay
            _calculatorPage.WaitForURLChange();
            String.Equals(_calculatorPage.CurrentURL(), "https://www.saucedemo.com/inventory.html").Should().BeTrue();
        }

        [Then("User is given a red prompt")]
        public void ThenUserIsGivenARedPrompt()
        {
            _calculatorPage.WaitForErrorMessage().Should().BeTrue();

            

        }
    }
}
