using Allure.Commons;
using Aquality.Selenium.Browsers;
using Aquality.Selenium.Template.Configurations;
using NUnit.Framework;

namespace Aquality.Selenium.Template.NUnit.Tests
{
    public abstract class BaseWebTest : BaseTest
    {

        [OneTimeSetUp]
        public void OneTimeSet()
        {
            AllureLifecycle.Instance.CleanupResultDirectory();
        }

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
            AqualityServices.Browser.GoTo(Configuration.StartUrl);
        }
    }
}
