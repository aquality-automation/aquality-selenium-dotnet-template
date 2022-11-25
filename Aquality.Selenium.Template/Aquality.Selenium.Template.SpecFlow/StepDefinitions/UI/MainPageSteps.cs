using Aquality.Selenium.Browsers;
using Aquality.Selenium.Template.Configurations;
using Aquality.Selenium.Template.Forms;
using Aquality.Selenium.Template.Forms.Pages;
using TechTalk.SpecFlow;

namespace Aquality.Selenium.Template.SpecFlow.StepDefinitions.UI
{
    [Binding]
    public class MainPageSteps
    {
        private readonly MainPage mainPage;

        public MainPageSteps(MainPage mainPage)
        {
            this.mainPage = mainPage;
        }

        [Given(@"Main page is opened")]
        public static void MainPageIsOpened()
        {
            AqualityServices.Browser.GoTo(Configuration.StartUrl);
        }

        [When(@"I open Contact us page")]
        public void IOpenContactUsPage()
        {
            mainPage.AcceptCookies();
            TopBarMenu.OpenHeaderMenu(TopBarMenu.Item.ContactUs);
        }
    }
}
