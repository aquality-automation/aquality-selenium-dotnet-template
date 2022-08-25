using Aquality.Selenium.Browsers;
using Aquality.Selenium.Configurations;
using Aquality.Selenium.Template.Forms.Pages;
using Aquality.Selenium.Template.NUnit.Constants;
using Aquality.Selenium.Template.NUnit.Extensions;
using NUnit.Framework;

namespace Aquality.Selenium.Template.NUnit.Steps
{
    public class MainPageSteps : BaseSteps
    {
        private readonly MainPage mainPage = new MainPage();

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
            AqualityServices.ConditionalWait.WaitForTrue(() => mainPage.IsAcceptCookiesButtonDisplayed,
            AqualityServices.Get<ITimeoutConfiguration>().Script, AqualityServices.Get<ITimeoutConfiguration>().PollingInterval,
                "Accept cookies button should not be displayed");
        }

        public void AcceptCookies()
        {
            LogStep();
            mainPage.AcceptCookies();
        }

        public void ScrollToTheFooter()
        {
            LogStep();
            var fullPageHeight = GetFullPageHeight();
            AqualityServices.Browser.ScrollWindowBy(0, fullPageHeight);
        }

        public int GetFullPageHeight()
        {
            LogStep();
            var pageHeight = AqualityServices.Browser.ExecuteScriptFromFile<long>(ResourceConstants.PathToGetFullPageHeightJS);
            return (int)(long)pageHeight;
        }
    }
}
