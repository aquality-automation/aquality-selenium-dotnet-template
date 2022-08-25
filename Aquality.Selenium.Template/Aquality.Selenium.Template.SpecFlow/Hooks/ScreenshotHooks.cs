using Allure.Commons;
using Aquality.Selenium.Browsers;
using Aquality.Selenium.Template.Utilities;
using NUnit.Framework;
using TechTalk.SpecFlow;
using AqualityTracking.Integrations.Core;

namespace Aquality.Selenium.Template.SpecFlow.Hooks
{
    [Binding]
    public class ScreenshotHooks
    {
        private readonly ScreenshotProvider screenshotProvider;

        public ScreenshotHooks(ScreenshotProvider screenshotProvider)
        {
            this.screenshotProvider = screenshotProvider;
        }

        [AfterScenario(Order = 0)]
        public void TakeScreenshot()
        {
            if (AqualityServices.IsBrowserStarted)
            {
                var pathToScreenshot = screenshotProvider.TakeScreenshot();
                TestContext.AddTestAttachment(pathToScreenshot);
                AllureLifecycle.Instance.AddAttachment(pathToScreenshot, "Screenshot");
                AqualityTrackingLifecycle.Instance.AddAttachment(pathToScreenshot);
            }
        }
    }
}
