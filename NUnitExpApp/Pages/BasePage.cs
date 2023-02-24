using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace NUnitExpApp.Pages
{
    internal abstract class BasePage
    {
        private IWebDriver driver;
        protected IWebDriver Driver { get => driver; private set => driver = value; }
        protected BasePage(IWebDriver driver, string pageTitle)
        {
            Driver = driver;
            AssertPageOpened(pageTitle);
        }

        #region Page navigation
        protected void AssertPageOpened(string pageTitle)
        {	
            var actualTitle = ((IJavaScriptExecutor)Driver).ExecuteScript("return document.title;").ToString();
            Assert.That(actualTitle, Is.EqualTo(pageTitle));
        }

        protected void NavigateToURL(string url)
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript($"window.location = '{url}'");
        }
        protected void ScrollDown(string pixels)
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript($"window.scrollBy(0,{pixels})");
        }
        protected void ReloadPage()
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript("location.reload()");
        }
        #endregion

        #region Elements interaction
        protected IWebElement ClickElement(IWebElement element)
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].click();", element);
            return element;
        }
        protected IWebElement SendText(IWebElement element, string text)
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript($"arguments[0].value= '{text}'", element);
            return element;
        }
        #endregion

        #region Waits
        protected void WaitExplicitUntilElementDisplayed(IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(d => element.Displayed);
        }

        protected void WaitFluentUntilElementDisplayed(IWebElement element)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(Driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.Until(d => element.Displayed);
        }
        #endregion
    }
}
