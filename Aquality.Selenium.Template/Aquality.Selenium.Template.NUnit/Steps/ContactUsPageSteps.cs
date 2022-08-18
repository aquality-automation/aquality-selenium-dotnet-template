using NUnit.Framework;
using System;
using Aquality.Selenium.Browsers;
using Aquality.Selenium.Template.Enums;
using Aquality.Selenium.Template.Forms.Pages;
using Aquality.Selenium.Template.NUnit.Extensions;
using Aquality.Selenium.Template.Models;
using Aquality.Selenium.Template.Extensions;
using Aquality.Selenium.Template.NUnit.Constants;
using Aquality.Selenium.Core.Utilities;
using System.Reflection;
using Newtonsoft.Json;
using Aquality.Selenium.Configurations;

namespace Aquality.Selenium.Template.NUnit.Steps
{
    public class ContactUsPageSteps : BaseSteps
    {
        private readonly ContactUsPage contactUsPage = new ContactUsPage();
        private readonly ContactUsInfo contactUsInfo = JsonConvert.DeserializeObject<ContactUsInfo>(FileReader.GetTextFromEmbeddedResource(ResourceConstants.PathToContactUserWithInvalidEmail, Assembly.GetCallingAssembly()));

        public void ContactUsPageIsPresent()
        {
            LogAssertion();
            contactUsPage.AssertIsPresent();
        }

        public void CheckThatTheContactUsFormElementsAreDisplayed()
        {
            LogAssertion();
            Assert.Multiple(() =>
            {
                foreach(ContactUsTextFields name in Enum.GetValues(typeof(ContactUsTextFields)))
                {
                    Assert.IsTrue(contactUsPage.IsContactUsTextBoxPresent(name), $"Text field {name} should be displayed");
                }
                Assert.IsTrue(contactUsPage.IsTermsCheckBoxExist, "Terms checkBox should be exist");
                Assert.IsTrue(contactUsPage.IsTermsLabelPresent, "Terms label should be displayed");
                Assert.IsTrue(contactUsPage.IsSendAMessageButtonPresent, "Send a message button should be displayed");
                Assert.IsTrue(contactUsPage.IsTitleLabelPresent, "Title should be displayed");
            });
        }

        public void CheckThanContactUsTitleIsCorrect()
        {
            LogAssertion();
            Assert.AreEqual(contactUsPage.TitleLabelTextValue, TitleConstants.TitleLabelText, "Title text should be same.");
        }

        public void ClickSendAMessageButton()
        {
            LogStep();
            contactUsPage.ClickSend();
        }

        public void CheckTermCheckBox()
        {
            LogStep();
            contactUsPage.CheckTermsCheckBox();
        }

        public void CheckTermCheckBoxIsCheckedOrNot(bool isChecked = false)
        {
            LogStep(nameof(CheckTermCheckBoxIsCheckedOrNot) + $"isChecked status - [{isChecked}]");
            var expectedStatus = isChecked ? "checked" : "not checked";
            Assert.AreEqual(contactUsPage.IsTermsCheckBoxChecked, isChecked, $"Term CheckBox should be {expectedStatus}");
        }

        public void SetValueForTheTextField(ContactUsTextFields textField, string value)
        {
            LogStep(nameof(SetValueForTheTextField) + $"Input user name - [{textField}]");
            contactUsPage.SetValueForContactUsTextBox(textField, value);
        }

        public void SetDataForTheAllTextFields()
        {
            LogStep();
            SetValueForTheTextField(ContactUsTextFields.Name, contactUsInfo.Name);
            SetValueForTheTextField(ContactUsTextFields.Email, contactUsInfo.Email);
            SetValueForTheTextField(ContactUsTextFields.Company, contactUsInfo.Company);
            SetValueForTheTextField(ContactUsTextFields.ProjectDescription, contactUsInfo.Comment);
        }

        public void CheckThatWarningEmailMessageisPresentOrNot(bool isChecked = false)
        {
            LogAssertion(nameof(CheckThatWarningEmailMessageisPresentOrNot) + $"isChecked status - [{isChecked}]");
            var expectedStatus = isChecked ? "displayed" : "not displayed";
            AqualityServices.ConditionalWait.WaitForTrue(() => contactUsPage.IsWarningEmailMessagePresent == isChecked,
             AqualityServices.Get<ITimeoutConfiguration>().Script, AqualityServices.Get<ITimeoutConfiguration>().PollingInterval,
                $"Warning email message should be {expectedStatus}.");
        }

        public void CheckThatWarningEmailMessageIsCorrect()
        {
            LogStep();
            Assert.AreEqual(contactUsPage.WarningEmailMessageTextValue, ContactUsTextFields.Email.GetEnumDescription(), "Warning email message should be correct.");
        }
    }
}
