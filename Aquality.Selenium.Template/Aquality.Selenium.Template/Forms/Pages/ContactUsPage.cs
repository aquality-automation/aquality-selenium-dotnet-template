using Aquality.Selenium.Elements.Interfaces;
using OpenQA.Selenium;

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
    }
}
