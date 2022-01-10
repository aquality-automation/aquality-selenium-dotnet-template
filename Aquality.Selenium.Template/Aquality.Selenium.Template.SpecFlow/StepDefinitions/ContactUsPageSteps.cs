using Aquality.Selenium.Template.Forms.Pages;
using Aquality.Selenium.Template.Models;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Aquality.Selenium.Template.SpecFlow.StepDefinitions
{
    [Binding]
    public class ContactUsPageSteps
    {
        private readonly ContactUsPage contactUsPage;

        public ContactUsPageSteps(ContactUsPage contactUsPage)
        {
            this.contactUsPage = contactUsPage;
        }

        [When(@"I accept Privacy and Cookies Policy")]
        public void IAcceptPrivacyAndCookiesPolicy()
        {
            contactUsPage.CheckPrivacyAndCookies();
        }

        [When(@"I save Contact us page dump")]
        public void ISaveContactUsPageDump()
        {
            contactUsPage.Dump.Save();
        }

        [When(@"I fill contact form using following data:")]
        public void IFillContactFormUsingFollowingData(ContactUsInfo contactUsInfo)
        {
            contactUsPage.SetName(contactUsInfo.Name)
                .SetCompany(contactUsInfo.Comment)
                .SetPhone(contactUsInfo.Phone)
                .SetComment(contactUsInfo.Comment);
        }

        [When(@"I click Send button")]
        public void IClickSendButton()
        {
            contactUsPage.ClickSend();
        }

        [Then(@"Contact us page is opened")]
        public void ContactUsPageIsOpened()
        {
            Assert.IsTrue(contactUsPage.State.WaitForDisplayed(), "Contact us page should be opened");
        }

        [Then(@"Notification about empty fields is present")]
        public void ThenNotificationAboutEmptyFieldsIsPresent()
        {
            Assert.IsTrue(contactUsPage.IsEmailValidationMessagePresent,
                "Email validation message should be displayed");
        }

        [Then(@"Contact us page dump is difference")]
        public void ContactUsPageDumpIsDifference()
        {
            Assert.That(contactUsPage.Dump.Compare(), Is.GreaterThan(0), 
                "The form dump should differ");
        }
    }
}
