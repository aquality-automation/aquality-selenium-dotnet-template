using Allure.Commons;
using Aquality.Selenium.Browsers;
using Aquality.Selenium.Template.Configurations;
using NUnit.Allure.Attributes;
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
