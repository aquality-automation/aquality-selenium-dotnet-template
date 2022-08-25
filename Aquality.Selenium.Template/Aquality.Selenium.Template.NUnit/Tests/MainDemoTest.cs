using Aquality.Selenium.Template.NUnit.Steps;
using NUnit.Framework;

namespace Aquality.Selenium.Template.NUnit.Tests
{
    public class MainDemoTest : BaseWebTest
    {
        private readonly MainPageSteps mainPageSteps = new MainPageSteps();

        [SetUp]
        public new void Setup()
        {
            GoToPageStartPage();
            SetScreenExpansionMaximize();
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
