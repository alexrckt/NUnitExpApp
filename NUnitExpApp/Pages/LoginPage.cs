using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitExpApp.Pages
{
    internal class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver, "Swag Labs") { }
        private IWebElement Username => Driver.FindElement(By.Id("user-name"));
        private IWebElement Password => Driver.FindElement(By.XPath("//input[id='password']"));
        private IWebElement LoginButton => Driver.FindElement(By.Name("login-button"));
        private IWebElement ErrorMessageContainer => Driver.FindElement(By.XPath("//div[contains(@class, 'error-message-container')]"));
        private IWebElement ErrorMessageText => ErrorMessageContainer.FindElement(By.XPath("//h3"));

        public LoginPage ClickLoginButton()
        {
            ClickElement(LoginButton);
            return this;
        }

        public LoginPage EnterUsername(string text)
        {
            Username.SendKeys(text);
            return this;
        }
        public LoginPage EnterPassword(string text)
        {
            Password.SendKeys(text);
            return this;
        }

        public LoginPage ErrorMessageEqualTo(string message)
        {
            Assert.That(ErrorMessageText.Text, Is.EqualTo(message));
            return this;
        }

        public LoginPage WaitExplicitUntilErrorMessageDisplayed()
        {
            WaitExplicitUntilElementDisplayed(ErrorMessageContainer);
            return this;
        }

        public LoginPage WaitFluentUntilErrorMessageDisplayed()
        {
            WaitFluentUntilElementDisplayed(ErrorMessageContainer);
            return this;
        }
    }
}
