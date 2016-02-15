using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowDemo
{
    [Binding]
    public class LogIn_FeatureSteps
    {
        public IWebDriver driver;

        [Given(@"User is at the Login Page")]
        public void GivenUserIsAtTheHomePage()
        {
            driver = new FirefoxDriver();
            driver.Url = "http://autoqa.pp.ua/wp-admin";
        }

        [When(@"User enter UserName and Password")]
        public void WhenUserEnterUserNameAndPassword()
        {
            driver.FindElement(By.Id("user_login")).SendKeys("subscriber");
            driver.FindElement(By.Id("user_pass")).SendKeys("subscriberpassword");
        }

        [When(@"Click on the LogIn button")]
        public void WhenClickOnTheLogInButton()
        {
            driver.FindElement(By.Id("wp-submit")).Click();
        }

        [When(@"User enter (.*) and (.*)")]
        public void WhenUserEnterAnd(string username, string password)
        {
            driver.FindElement(By.Id("user_login")).SendKeys(username);
            driver.FindElement(By.Id("user_pass")).SendKeys(password);
        }

        [Then(@"Successful LogIN message should display")]
        public void ThenSuccessfulLogINMessageShouldDisplay()
        {
            if (driver.FindElement(By.Id("profile-page")).Displayed)
            {
                // Print a Log In message to the screen 
                Console.WriteLine("Login successfully.");
            }

            // Close the driver

            driver.Close();
        }


    }
}
