using Aquality.Selenium.Elements.Interfaces;
using OpenQA.Selenium;
using Aquality.Selenium.Template.Enums;
using Aquality.Selenium.Core.Elements;

namespace Aquality.Selenium.Template.Forms.Pages
{
    public class ContactUsPage : BaseAppForm
    {
        private ITextBox NameTxb => ElementFactory.GetTextBox(By.Id("your-name"), "Name");
        private ITextBox CompanyTxb => ElementFactory.GetTextBox(By.Id("your-company"), "Company");
        private ITextBox PhoneTxb => ElementFactory.GetTextBox(By.Id("your-phone"), "Phone");
        private ITextBox CommentTxb => ElementFactory.GetTextBox(By.Id("your-message"), "Project description");
        private ICheckBox PrivacyChbx => ElementFactory.GetCheckBox(By.XPath("//input[@name='privacy']/following-sibling::span[1]"), "Privacy");
        private IButton SendBtn => ElementFactory.GetButton(By.XPath("//div[@class='contactsForm__submit']//button"), "Send a message");
        private ILabel EmailAlertLbl => ElementFactory.GetLabel(By.XPath("//div[contains(@class,'error')]//input[@id='your-email']"), "Email validating message", Core.Elements.ElementState.ExistsInAnyState);
        private ILabel TitleLbl => FormElement.FindChildElement<ILabel>(By.XPath("//h2[contains(@class,'blockTitle')]"), "Title");
        private ILabel TermsLbl => FormElement.FindChildElement<ILabel>(By.XPath("//label[contains(@class, 'checkbox')]"), "Terms");
        private ITextBox ContatcUsTextBox(ContactUsTextFields contactUsTextField) => ElementFactory.GetTextBox(By.Id($"{contactUsTextField.GetId()}"), contactUsTextField.ToString());
        private ILabel WarningEmailMessageLbl => ContatcUsTextBox(ContactUsTextFields.Email).FindChildElement<ILabel>(By.XPath("/parent::*/div[@class = 'input__error']"), "Warning email message");
        private ICheckBox TermsChbx => FormElement.FindChildElement<ICheckBox>(By.XPath("//input[@type='checkbox']"), "Terms", null, ElementState.ExistsInAnyState);

        public bool IsEmailValidationMessagePresent => EmailAlertLbl.State.WaitForDisplayed();

        public ContactUsPage() : base(By.ClassName("contactsForm__wrapper"), "Contact Us")
        {
        }

        public ContactUsPage SetName(string name)
        {
            NameTxb.ClearAndType(name);
            return this;
        }

        public ContactUsPage SetCompany(string company)
        {
            CompanyTxb.ClearAndType(company);
            return this;
        }

        public ContactUsPage SetPhone(string phone)
        {
            PhoneTxb.ClearAndType(phone);
            return this;
        }

        public ContactUsPage SetComment(string comment)
        {
            CommentTxb.ClearAndType(comment);
            return this;
        }

        public void CheckPrivacyAndCookies() => PrivacyChbx.Check();

        public void ClickSend() => SendBtn.Click();

        public bool IsTitleLabelPresent => TitleLbl.State.IsDisplayed;

        public string TitleLabelTextValue => TitleLbl.GetText();

        public bool IsSendAMessageButtonPresent => SendBtn.State.IsDisplayed;

        public bool IsContatcUsTextBoxPresent(ContactUsTextFields contactUsTextField) => ContatcUsTextBox(contactUsTextField).State.IsDisplayed;

        public void SetValueForContatcUsTextBox(ContactUsTextFields contactUsTextField, string value) => ContatcUsTextBox(contactUsTextField).ClearAndType(value);

        public bool IsTermsCheckBoxExist => TermsChbx.State.IsExist;

        public bool IsTermsLabelPresent => TermsLbl.State.IsDisplayed;

        public void CheckTermsCheckBox() => TermsLbl.Click();

        public bool IsTermsCheckBoxChecked => TermsChbx.IsChecked;

        public bool IsWarningEmailMessagePresent => WarningEmailMessageLbl.State.IsDisplayed;

        public string WarningEmailMessageTextValue => WarningEmailMessageLbl.GetText();
    }
}
