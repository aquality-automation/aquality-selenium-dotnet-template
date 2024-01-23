using Aquality.Selenium.Browsers;
using Aquality.Selenium.Template.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

[assembly: Parallelizable(ParallelScope.Fixtures)]

namespace Aquality.Selenium.Template.SpecFlow.Hooks
{
    [Binding]
    public class BrowserHooks(ScreenshotProvider screenshotProvider)
    {
        private readonly ScreenshotProvider screenshotProvider = screenshotProvider;

        [AfterScenario(Order = 0)]
        public void AttachArtifacts()
        {
            if (AqualityServices.IsBrowserStarted)
            {
                AttachmentHelper.AddAttachment(screenshotProvider.TakeScreenshot(), "Screenshot");
                AttachmentHelper.AddAttachment("source", "text/html", AqualityServices.Browser.Driver.PageSource, ".html");
                AttachmentHelper.AddAttachmentAsJson("console.log", AqualityServices.Browser.GetLogs(LogType.Browser));
            }
        }

        [AfterScenario(Order = 1)]
        public void CloseBrowser()
        {
            if (AqualityServices.IsBrowserStarted)
            {
                AqualityServices.Browser.Quit();
            }
        }
    }
}
