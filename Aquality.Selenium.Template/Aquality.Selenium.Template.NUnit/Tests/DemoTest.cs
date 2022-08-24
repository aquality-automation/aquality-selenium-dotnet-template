using Aquality.Selenium.Template.NUnit.Steps;
using NUnit.Framework;

namespace Aquality.Selenium.Template.NUnit.Tests
{
    public class DemoTest : BaseWebTest
    {
        private readonly TopBarMenuSteps topBarMenuSteps = new TopBarMenuSteps();
        private readonly MainPageSteps mainPageSteps = new MainPageSteps();
        private readonly ContactUsPageSteps contactUsFormSteps = new ContactUsPageSteps();
        private readonly FooterFormSteps footerFormSteps = new FooterFormSteps();

        [SetUp]
        public new void Setup()
        {
            GoToPageStartPage();
            SetScreenExpansionMaximize();
            mainPageSteps.MainPageIsPresent();
            mainPageSteps.AcceptCookies();
        }

        [Test(Description = "TC-0002 Check all navigation panel elements are present")]
        public void TC0002_CheckThePossibilityToChangeTheLanguageFromGermanToEnglish()
        {
            topBarMenuSteps.TopBarMenuIsPresent();
            topBarMenuSteps.ContactUsButtonIsPresent();
            topBarMenuSteps.CheckThatNavigationElementsAreCorrect();
            topBarMenuSteps.MoveToTheServicesNavigationTab();
            topBarMenuSteps.CheckThatServicesTitlesAreDispalayedAndCorrect();
        }

        [Test(Description = "TC-0003 Check how the Contact Us form works with an incorrect email")]
        public void TC0003_CheckHowTheContactUsFormWorksWithAnIncorrectEmail()
        {
            topBarMenuSteps.TopBarMenuIsPresent();
            topBarMenuSteps.ClickContactUs();
            contactUsFormSteps.ContactUsPageIsPresent();
            contactUsFormSteps.CheckThatTheContactUsFormElementsAreDisplayed();
            contactUsFormSteps.CheckThanContactUsTitleIsCorrect();
            contactUsFormSteps.SetDataForTheAllTextFields();
            contactUsFormSteps.CheckTermCheckBoxIsCheckedOrNot();
            contactUsFormSteps.CheckTermCheckBox();
            contactUsFormSteps.CheckTermCheckBoxIsCheckedOrNot(true);
            contactUsFormSteps.CheckThatWarningEmailMessageisPresentOrNot();
            contactUsFormSteps.ClickSendAMessageButton();
            contactUsFormSteps.CheckThatWarningEmailMessageisPresentOrNot(true);
            contactUsFormSteps.CheckThatWarningEmailMessageIsCorrect();
        }

        [Test(Description = "TC-0004 Check the footer form is correct with visual testing")]
        public void TC0004_CheckTheFooterFormIsCorrectWithVisualTesting()
        {
            topBarMenuSteps.TopBarMenuIsPresent();
            mainPageSteps.ScrollToTheFooter();
            footerFormSteps.FooterFormIsPresent();
            footerFormSteps.CheckVisualElementsPresent();
            //footerFormSteps.SaveDump(); // - this method is used locally, only to fill the image dump.
            footerFormSteps.CheckThatTheVisualElementsAreCorrect();
        }
    }
}
