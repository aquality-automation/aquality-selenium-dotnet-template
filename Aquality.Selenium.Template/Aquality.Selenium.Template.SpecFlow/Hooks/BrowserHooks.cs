using Aquality.Selenium.Browsers;
using TechTalk.SpecFlow;

namespace Aquality.Selenium.Template.Glue.Hooks
{
    [Binding]
    public class BrowserHooks
    {
        [AfterScenario(Order = 1)]
        public void CloseBrowser()
        {
            AqualityServices.Browser.Quit();
        }
    }
}
