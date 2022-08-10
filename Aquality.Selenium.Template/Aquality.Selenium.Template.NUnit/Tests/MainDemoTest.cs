using Aquality.Selenium.Browsers;
using Aquality.Selenium.Template.NUnit.Constants;
using Aquality.Selenium.Template.NUnit.Models;
using Aquality.Selenium.Template.NUnit.Steps;
using Aquality.Selenium.Template.Utilities;
using NUnit.Framework;

namespace Aquality.Selenium.Template.NUnit.Tests
{
    public class MainDemoTest : BaseTest
    {
        private readonly MainPageSteps mainPageSteps = new MainPageSteps();
        private readonly TestData testData = FileReader.ReadJsonData<TestData>(ResourceConstants.PathToTestData);

        [SetUp]
        public new void Setup()
        {
            GoToPage(testData.Url);
            SetScreenExpansionMaximize();
        }

        [TearDown]
        public new void AfterEach()
        {
            AqualityServices.Browser.Quit();
        }

        [Test(Description = "TC-0001 Check the cookie form")]
        public void TC0001_CheckTheCookieForm()
        {
            mainPageSteps.MainPageIsPresent();
            mainPageSteps.AcceptCookiesButtonIsDisplayed();
            mainPageSteps.AcceptCookies();
            mainPageSteps.AcceptCookiesButtonIsNotDisplayed();
        }
    }
}
