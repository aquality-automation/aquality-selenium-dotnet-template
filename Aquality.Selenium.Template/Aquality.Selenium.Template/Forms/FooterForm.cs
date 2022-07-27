using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using Aquality.Selenium.Template.Constants;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace Aquality.Selenium.Template.Forms
{
    public class FooterForm : Form
    {
        private ILabel LogoLbl => FormElement.FindChildElement<ILabel>(By.XPath("//a[contains(@class,'footer__logo')]"), "Logo");

        private ILabel ContactsLbl => FormElement.FindChildElement<ILabel>(By.XPath("//div[contains(@class,'footer__contacts')]"), "Contacts");

        private ILabel SubscribeLbl => FormElement.FindChildElement<ILabel>(By.XPath("//div[contains(@class,'footer__subscribe')]"), "Subscribe");

        public FooterForm() : base(By.TagName("footer"), "Footer form")
        {
        }

        public bool IsLogoPresent => LogoLbl.State.WaitForDisplayed(ProjectConstants.ShortTimeout);

        public bool IsContactsPresent => ContactsLbl.State.WaitForDisplayed(ProjectConstants.ShortTimeout);

        public bool IsSubscribePresent => SubscribeLbl.State.WaitForDisplayed(ProjectConstants.ShortTimeout);

        protected override IDictionary<string, IElement> ElementsForVisualization => new Dictionary<string, IElement>()
        {
            {"Footer logo", LogoLbl },
            {"Footer contacts", ContactsLbl },
            {"Footer subscribe", SubscribeLbl },
        };
    }
}
