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
using Aquality.Selenium.Template.CustomAttributes;

namespace Aquality.Selenium.Template.NUnit.Steps
{
    public class ContactUsPageSteps
    {
        private readonly ContactUsPage contactUsPage = new ContactUsPage();
        private readonly ContactUsInfo contactUsInfo = JsonConvert.DeserializeObject<ContactUsInfo>(FileReader.GetTextFromEmbeddedResource(ResourceConstants.PathToContactUserWithInvalidEmail, Assembly.GetCallingAssembly()));

        [LogStep(StepType.Assertion)]
        public void ContactUsPageIsPresent()
        {
            contactUsPage.AssertIsPresent();
        }

        [LogStep(StepType.Assertion)]
        public void CheckThatTheContactUsFormElementsAreDisplayed()
        {
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

        [LogStep(StepType.Assertion)]
        public void CheckThanContactUsTitleIsCorrect()
        {
            Assert.AreEqual(contactUsPage.TitleLabelTextValue, TitleConstants.TitleLabelText, "Title text should be same.");
        }

        [LogStep(StepType.Step)]
        public void ClickSendAMessageButton()
        {
            contactUsPage.ClickSend();
        }

        [LogStep(StepType.Step)]
        public void CheckTermCheckBox()
        {
            contactUsPage.CheckTermsCheckBox();
        }

        [LogStep(StepType.Step)]
        public void CheckTermCheckBoxIsCheckedOrNot(bool isChecked = false)
        {
            var expectedStatus = isChecked ? "checked" : "not checked";
            Assert.AreEqual(contactUsPage.IsTermsCheckBoxChecked, isChecked, $"Term CheckBox should be {expectedStatus}");
        }

        [LogStep(StepType.Step)]
        public void SetValueForTheTextField(ContactUsTextFields textField, string value)
        {
            contactUsPage.SetValueForContactUsTextBox(textField, value);
        }

        [LogStep(StepType.Step)]
        public void SetDataForTheAllTextFields()
        {
            SetValueForTheTextField(ContactUsTextFields.Name, contactUsInfo.Name);
            SetValueForTheTextField(ContactUsTextFields.Email, contactUsInfo.Email);
            SetValueForTheTextField(ContactUsTextFields.Company, contactUsInfo.Company);
            SetValueForTheTextField(ContactUsTextFields.ProjectDescription, contactUsInfo.Comment);
        }

        [LogStep(StepType.Assertion)]
        public void CheckThatWarningEmailMessageisPresentOrNot(bool isChecked = false)
        {
            var expectedStatus = isChecked ? "displayed" : "not displayed";
            AqualityServices.ConditionalWait.WaitForTrue(() => contactUsPage.IsWarningEmailMessagePresent == isChecked,
            AqualityServices.Get<ITimeoutConfiguration>().Script, AqualityServices.Get<ITimeoutConfiguration>().PollingInterval,
                $"Warning email message should be {expectedStatus}.");
        }

        [LogStep(StepType.Step)]
        public void CheckThatWarningEmailMessageIsCorrect()
        {
            Assert.AreEqual(contactUsPage.WarningEmailMessageTextValue, ContactUsTextFields.Email.GetEnumDescription(), "Warning email message should be correct.");
        }
    }
}
