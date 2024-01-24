using Aquality.Selenium.Browsers;
using Aquality.Selenium.Template.Configurations;
using Aquality.Selenium.Template.Utilities;
using NUnit.Allure.Attributes;
using NUnit.Framework.Interfaces;

namespace Aquality.Selenium.Template.NUnit.Tests
{
    public abstract class BaseWebTest : BaseTest
    {
        private readonly ScreenshotProvider screenshotProvider = new();

        public override void AfterEach()
        {
            base.AfterEach();
            if (AqualityServices.IsBrowserStarted)
            {
                if (Result.Outcome.Status != TestStatus.Passed)
                {
                    AttachmentHelper.AddAttachment(screenshotProvider.TakeScreenshot(), "Screenshot");
                }
                AqualityServices.Browser.Quit();
            }
        }

        [AllureStep]
        public static void SetScreenExpansionMaximize()
        {
            AqualityServices.Browser.Maximize();
        }

        [AllureStep]
        public static void GoToPageStartPage()
        {
            AqualityServices.Browser.GoTo(Configuration.StartUrl);
        }
    }
}
