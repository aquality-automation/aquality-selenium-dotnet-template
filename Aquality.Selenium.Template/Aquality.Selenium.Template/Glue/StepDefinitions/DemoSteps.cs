using Aquality.Selenium.Browsers;
using Aquality.Selenium.Template.Forms;
using Aquality.Selenium.Template.Forms.Pages;
using Aquality.Selenium.Template.Models;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Aquality.Selenium.Template.Glue.StepDefinitions
{
    [Binding]
    public class DemoSteps
    {
        private readonly ContactUsPage contactUsPage;

        public DemoSteps(ContactUsPage contactUsPage)
        {
            this.contactUsPage = contactUsPage;
        }

        [Given(@"Main page is opened")]
        public void GivenMainPageIsOpened()
        {
            AqualityServices.Browser.GoTo("https://www.a1qa.com/"); // TODO: read from config
        }
        
        [When(@"I open Contact us page")]
        public void WhenIOpenContactUsPage()
        {
            var mainPage = new MainPage();
            mainPage.AcceptCookies();
            var topBarMenu = new TopBarMenu();
            topBarMenu.OpenHeaderMenu(TopBarMenu.Item.ContactUs);
        }
        
        [When(@"I fill contact form using following data:")]
        public void WhenIFillContactFormUsingFollowingData(ContactUsInfo contactUsInfo)
        {
            contactUsPage.SetName(contactUsInfo.Name)
                .SetCompany(contactUsInfo.Comment)
                .SetPhone(contactUsInfo.Phone)
                .SetComment(contactUsInfo.Comment);
        }
        
        [When(@"I accept Privacy and Cookies Policy")]
        public void WhenIAcceptPrivacyAndCookiesPolicy()
        {
            var contactUsPage = new ContactUsPage();
            contactUsPage.CheckPrivacyAndCookies();
        }
        
        [When(@"I click Send button")]
        public void WhenIClickSendButton()
        {
            contactUsPage.ClickSend();
        }
        
        [Then(@"Contact us page is opened")]
        public void ThenContactUsPageIsOpened()
        {
            Assert.IsTrue(contactUsPage.IsDisplayed, "Contact us page is opened");
        }
        
        [Then(@"Notification about empty fields is present")]
        public void ThenNotificationAboutEmptyFieldsIsPresent()
        {
            Assert.IsTrue(contactUsPage.IsEmailValidationMessagePresent,
                "Email validation message should be displayed");
        }
    }
}
