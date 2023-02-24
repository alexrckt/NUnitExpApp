using NUnit.Allure.Core;
using NUnitExpApp.Pages;

namespace NUnitExpApp.TestCases
{
    [TestFixture]
    [AllureNUnit]
    public class Tests : BaseTest
    {
        [Test]
        public void TestImplicitWait()
        {
            new LoginPage(Driver)
                .ClickLoginButton()
                .ErrorMessageEqualTo("Epic sadface: Username is required");
        }

        [Test]
        public void TestWaitBadPractive()
        {
            var page = new LoginPage(Driver)
                .EnterUsername("test")
                .ClickLoginButton();

            Thread.Sleep(3000);

            page.ErrorMessageEqualTo("Epic sadface: Password is required");
        }

        [Test]
        public void TestExplisitWait()
        {
            new LoginPage(Driver)
                .ClickLoginButton()
                .WaitExplicitUntilErrorMessageDisplayed()
                .ErrorMessageEqualTo("Epic sadface: Username is required");
        }

        [Test]
        public void TestFluentWait()
        {
            new LoginPage(Driver)
                .ClickLoginButton()
                .WaitFluentUntilErrorMessageDisplayed()
                .ErrorMessageEqualTo("Epic sadface: Username is required");
        }
    }
}