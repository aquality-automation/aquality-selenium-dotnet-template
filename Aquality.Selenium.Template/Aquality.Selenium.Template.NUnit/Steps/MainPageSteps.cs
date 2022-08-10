using Aquality.Selenium.Browsers;
using Aquality.Selenium.Template.Forms.Pages;
using Aquality.Selenium.Template.NUnit.Extensions;
using NUnit.Framework;
using System;

namespace Aquality.Selenium.Template.NUnit.Steps
{
    public class MainPageSteps : BaseSteps
    {
        private readonly MainPage mainPage = new MainPage();

        public MainPageSteps()
        {
        }

        public void MainPageIsPresent()
        {
            LogAssertion();
            mainPage.AssertIsPresent();
        }


        public void AcceptCookiesButtonIsDisplayed()
        {
            LogAssertion();
            Assert.IsTrue(mainPage.IsAcceptCookiesButtonDisplayed, "Accept cookies button should be displayed");
        }

        public void AcceptCookiesButtonIsNotDisplayed()
        {
            LogAssertion();
            AqualityServices.ConditionalWait.WaitForTrue(() => {
                return mainPage.IsAcceptCookiesButtonDisplayed;
            },
             TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(5),
                "Accept cookies button should not be displayed");
        }

        public void AcceptCookies()
        {
            LogStep();
            mainPage.AcceptCookies();
        }
    }
}
