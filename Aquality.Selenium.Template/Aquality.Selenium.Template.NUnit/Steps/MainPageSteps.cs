using Aquality.Selenium.Browsers;
using Aquality.Selenium.Configurations;
using Aquality.Selenium.Template.CustomAttributes;
using Aquality.Selenium.Template.Forms.Pages;
using Aquality.Selenium.Template.NUnit.Constants;
using Aquality.Selenium.Template.NUnit.Extensions;
using NUnit.Framework;

namespace Aquality.Selenium.Template.NUnit.Steps
{
    public class MainPageSteps
    {
        private readonly MainPage mainPage = new MainPage();

        [LogStep(StepType.Assertion)]
        public void MainPageIsPresent()
        {
            mainPage.AssertIsPresent();
        }

        [LogStep(StepType.Assertion)]
        public void AcceptCookiesButtonIsDisplayed()
        {
            Assert.IsTrue(mainPage.IsAcceptCookiesButtonDisplayed, "Accept cookies button should be displayed");
        }

        [LogStep(StepType.Assertion)]
        public void AcceptCookiesButtonIsNotDisplayed()
        {
            AqualityServices.ConditionalWait.WaitForTrue(() => mainPage.IsAcceptCookiesButtonDisplayed,
            AqualityServices.Get<ITimeoutConfiguration>().Script, AqualityServices.Get<ITimeoutConfiguration>().PollingInterval,
                "Accept cookies button should not be displayed");
        }

        [LogStep(StepType.Step)]
        public void AcceptCookies()
        {
            mainPage.AcceptCookies();
        }

        [LogStep(StepType.Step)]
        public static void ScrollToTheFooter()
        {
            var fullPageHeight = GetFullPageHeight();
            AqualityServices.Browser.ScrollWindowBy(0, fullPageHeight);
        }

        [LogStep(StepType.Step)]
        public static int GetFullPageHeight()
        {
            var pageHeight = AqualityServices.Browser.ExecuteScriptFromFile<long>(ResourceConstants.PathToGetFullPageHeightJS);
            return (int)(long)pageHeight;
        }
    }
}
