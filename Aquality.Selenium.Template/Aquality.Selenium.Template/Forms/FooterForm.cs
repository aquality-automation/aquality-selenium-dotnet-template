using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using Aquality.Selenium.Template.Interfaces;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace Aquality.Selenium.Template.Forms
{
    public class FooterForm : Form
    {
        private ILabel LogoLabel => FormElement.FindChildElement<ILabel>(By.XPath("//a[contains(@class,'footer__logo')]"), "Logo");

        private ILabel ContactsLabel => FormElement.FindChildElement<ILabel>(By.XPath("//div[contains(@class,'footer__contacts')]"), "Contacts");

        private ILabel SubscribeLabel => FormElement.FindChildElement<ILabel>(By.XPath("//div[contains(@class,'footer__subscribe')]"), "Subscribe");

        public FooterForm() : base(By.TagName("footer"), "Footer form")
        {
        }

        public bool IsLogoPresent => LogoLabel.State.WaitForDisplayed(AqualityServices.Get<ICustomTimeoutConfiguration>().ElementAppear);

        public bool IsContactsPresent => ContactsLabel.State.WaitForDisplayed(AqualityServices.Get<ICustomTimeoutConfiguration>().ElementAppear);

        public bool IsSubscribePresent => SubscribeLabel.State.WaitForDisplayed(AqualityServices.Get<ICustomTimeoutConfiguration>().ElementAppear);

        protected override IDictionary<string, IElement> ElementsForVisualization => new Dictionary<string, IElement>()
        {
            {"Footer logo", LogoLabel },
            {"Footer contacts", ContactsLabel },
            {"Footer subscribe", SubscribeLabel },
        };
    }
}
