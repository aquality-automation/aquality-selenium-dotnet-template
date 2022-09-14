using Aquality.Selenium.Browsers;
using NUnit.Framework;
using TechTalk.SpecFlow;

[assembly: Parallelizable(ParallelScope.Fixtures)]

namespace Aquality.Selenium.Template.SpecFlow.Hooks
{
    [Binding]
    public class BrowserHooks
    {
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
