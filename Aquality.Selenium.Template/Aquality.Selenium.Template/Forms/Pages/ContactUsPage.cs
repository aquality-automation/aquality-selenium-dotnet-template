using Aquality.Selenium.Elements.Interfaces;
using OpenQA.Selenium;

namespace Aquality.Selenium.Template.Forms.Pages
{
    public class ContactUsPage : BaseAppForm
    {
        private ITextBox NameTxb => ElementFactory.GetTextBox(By.Id("name"), "Name");
        private ITextBox CompanyTxb => ElementFactory.GetTextBox(By.Id("company"), "Company");
        private ITextBox PhoneTxb => ElementFactory.GetTextBox(By.Id("phone"), "Phone");
        private ITextBox CommentTxb => ElementFactory.GetTextBox(By.Id("message"), "Comment");
        private ICheckBox PrivacyChbx => ElementFactory.GetCheckBox(By.Name("privacy"), "Privacy");
        private IButton SendBtn => ElementFactory.GetButton(By.XPath("//input[@value='Send']"), "Send");
        private ILabel EmailAlertLbl => ElementFactory.GetLabel(By.XPath("//span[@role='alert']//preceding-sibling::input[@id='email']"), "Email validating message");

        public bool IsEmailValidationMessagePresent => EmailAlertLbl.State.WaitForDisplayed();

        public ContactUsPage() : base(By.Id("contact-us"), "Contact Us")
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

        public ContactUsPage CheckPrivacyAndCookies()
        {
            PrivacyChbx.Check();
            return this;
        }

        public void ClickSend()
        {
            SendBtn.Click();
        }
    }
}
