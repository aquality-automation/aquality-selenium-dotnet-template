using Aquality.Selenium.Template.Utilities;
using System;
using TechTalk.SpecFlow;

namespace Aquality.Selenium.Template.SpecFlow.Hooks
{
    [Binding]
    public class ScreenshotHooks
    {
        private readonly ScreenshotProvider screenshotProvider;
        private readonly ScenarioContext scenarioContext;

        public ScreenshotHooks(ScenarioContext scenarioContext, ScreenshotProvider screenshotProvider)
        {
            this.scenarioContext = scenarioContext;
            this.screenshotProvider = screenshotProvider;
        }

        [AfterScenario(Order = 0)]
        public void TakeScreenshot()
        {
            if (scenarioContext.ScenarioExecutionStatus != ScenarioExecutionStatus.OK)
            {
                var screenshotName = $"{GetType().Name}_{DateTime.Now:yyyyMMdd_HHmmss}_{Guid.NewGuid().ToString("n").Substring(0, 5)}";
                screenshotProvider.PublishScreenshot(screenshotName);
            }
        }
    }
}
