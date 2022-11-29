using Aquality.Selenium.Elements.Interfaces;
using OpenQA.Selenium;
using Aquality.Selenium.Template.Enums;
using Aquality.Selenium.Core.Elements;
using Aquality.Selenium.Core.Visualization;
using Aquality.Selenium.Template.Configurations;

namespace Aquality.Selenium.Template.Forms.Pages
{
    public class ContactUsPage : BaseAppForm
    {
        private ITextBox NameTextBox => ElementFactory.GetTextBox(By.Id("your-name"), "Name");
        private ITextBox CompanyTextBox => ElementFactory.GetTextBox(By.Id("your-company"), "Company");
        private ITextBox PhoneTextBox => ElementFactory.GetTextBox(By.Id("your-phone"), "Phone");
        private ITextBox CommentTextBox => ElementFactory.GetTextBox(By.Id("your-message"), "Project description");
        private ICheckBox PrivacyCheckBox => ElementFactory.GetCheckBox(By.XPath("//input[@name='privacy']/following-sibling::span[1]"), "Privacy");
        private IButton SendButton => ElementFactory.GetButton(By.XPath("//div[contains(@class,'contactsForm__submit')]//button"), "Send a message");
        private ILabel EmailAlertLabel => ElementFactory.GetLabel(By.XPath("//div[contains(@class,'error')]//input[@id='your-email']"), "Email validating message", Core.Elements.ElementState.ExistsInAnyState);
        private ILabel TitleLabel => FormElement.FindChildElement<ILabel>(By.XPath("//h2[contains(@class,'blockTitle')]"), "Title");
        private ILabel TermsLabel => FormElement.FindChildElement<ILabel>(By.XPath("//label[contains(@class, 'checkbox')]"), "Terms");
        private ITextBox ContactUsTextBox(ContactUsTextFields contactUsTextField) => ElementFactory.GetTextBox(By.Id($"{contactUsTextField.GetId()}"), contactUsTextField.ToString());
        private ILabel WarningEmailMessageLabel => ContactUsTextBox(ContactUsTextFields.Email).FindChildElement<ILabel>(By.XPath("/parent::*/div[contains(@class, 'input__error')]"), "Warning email message");
        private ICheckBox TermsCheckBox => FormElement.FindChildElement<ICheckBox>(By.XPath("//input[@type='checkbox']"), "Terms", null, ElementState.ExistsInAnyState);

        public ContactUsPage() : base(By.ClassName("contactsForm__wrapper"), "Contact Us")
        {
        }

        public override IDumpManager Dump => new CustomDumpManager<IElement>(ElementsForVisualization, Name, VisualizationConfiguration, LocalizedLogger);

        public bool IsEmailValidationMessagePresent => EmailAlertLabel.State.WaitForDisplayed();

        public ContactUsPage SetName(string name)
        {
            NameTextBox.ClearAndType(name);
            return this;
        }

        public ContactUsPage SetCompany(string company)
        {
            CompanyTextBox.ClearAndType(company);
            return this;
        }

        public ContactUsPage SetPhone(string phone)
        {
            PhoneTextBox.ClearAndType(phone);
            return this;
        }

        public ContactUsPage SetComment(string comment)
        {
            CommentTextBox.ClearAndType(comment);
            return this;
        }

        public void CheckPrivacyAndCookies() => PrivacyCheckBox.Check();

        public void ClickSend() => SendButton.Click();

        public bool IsTitleLabelPresent => TitleLabel.State.IsDisplayed;

        public string TitleLabelTextValue => TitleLabel.GetText();

        public bool IsSendAMessageButtonPresent => SendButton.State.IsDisplayed;

        public bool IsContactUsTextBoxPresent(ContactUsTextFields contactUsTextField) => ContactUsTextBox(contactUsTextField).State.IsDisplayed;

        public void SetValueForContactUsTextBox(ContactUsTextFields contactUsTextField, string value) => ContactUsTextBox(contactUsTextField).ClearAndType(value);

        public bool IsTermsCheckBoxExist => TermsCheckBox.State.IsExist;

        public bool IsTermsLabelPresent => TermsLabel.State.IsDisplayed;

        public void CheckTermsCheckBox() => TermsLabel.Click();

        public bool IsTermsCheckBoxChecked => TermsCheckBox.IsChecked;

        public bool IsWarningEmailMessagePresent => WarningEmailMessageLabel.State.IsDisplayed;

        public string WarningEmailMessageTextValue => WarningEmailMessageLabel.GetText();
    }
}
