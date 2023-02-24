using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace NUnitExpApp
{
    public class BaseTest
    {
        private IWebDriver driver;
        protected IWebDriver Driver { get => driver; private set => driver = value; }

        private string baseURL = "https://www.saucedemo.com/";

        [SetUp]
        public void BaseSetUp()
        {
            if (true) //remote var empty?
            {
                Console.WriteLine("Starting local test");
                Driver = new ChromeDriver();
                Navigate(baseURL);
            }
            else
            {
                Console.WriteLine("Starting remote test");
            }

            //IMPLICIT waits
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
        }

        [TearDown]
        public void BaseTearDown()
        {
            Driver.Quit();
        }

        public void Navigate(string URL)
        {
            Driver.Url = URL;
            Driver.Navigate();
        }
    }
}
