using Aquality.Selenium.Browsers;
using NUnit.Framework;

namespace Aquality.Selenium.Template.NUnit.Tests
{
    public abstract class BaseWebTest : BaseTest
    {
        [TearDown]
        public void CleanUp()
        {
            if (AqualityServices.IsBrowserStarted)
            {
                AqualityServices.Browser.Quit();
            }
        }

        public void SetScreenExpansionMaximize()
        {
            AqualityServices.Browser.Maximize();
        }

        public void GoToPageStartPage()
        {
            AqualityServices.Browser.GoTo(Configuration.Configuration.StartUrl);
        }
    }
}
