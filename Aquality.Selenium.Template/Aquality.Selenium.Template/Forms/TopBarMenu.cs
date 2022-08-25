using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using Aquality.Selenium.Template.Extensions;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace Aquality.Selenium.Template.Forms
{
    public class TopBarMenu : Form
    {
        private static readonly IDictionary<Item, string> menuItems = new Dictionary<Item, string>
        {
            { Item.ContactUs, "//div[@class='header__contact']//a" }
        };

        private IList<ILabel> ServicesTitlesElements => ElementFactory.FindElements<ILabel>(By.XPath("//div[contains(@class,'menu__dropdown')]//h3"), "Service titles");

        private ILabel LogoLabel => FormElement.FindChildElement<ILabel>(By.XPath("//a[@aria-label='a1qa home page']"), "Logo");

        private IButton ContactUsButton => ElementFactory.GetButton(By.XPath("//div[contains(@class,'header__contact')]"), "Contact Us");

        private IButton TabButtonByName(string buttonName) => ElementFactory.GetButton(By.XPath($"//nav/ul/li/button[contains(text(),'{buttonName}')]"), $"{buttonName}");

        private IList<ILabel> HeadersTabElements => ElementFactory.GetNotEmptyElementList<ILabel>(By.XPath("(//nav/ul/li/button | //nav/ul/li/a)"), "Header elements");

        public TopBarMenu() : base(By.TagName("header"), "Header")
        {
        }

        public void OpenHeaderMenu(Item menuItem) => ElementFactory.GetButton(By.XPath(menuItems[menuItem]), menuItem.ToString()).ClickAndWait();

        public bool IsLogoElementDisplayed => LogoLabel.State.IsDisplayed;

        public bool IsContactUsButtonExist => ContactUsButton.State.IsExist;

        public void ClickContactUs() => ContactUsButton.Click();

        public IList<string> GetTextForHeaderNavigationElements => HeadersTabElements.Select(x => x.GetText()).ToList();

        public void MoveToTheTabButton(string buttonName) => TabButtonByName(buttonName).MouseActions.MoveToElement();

        public IList<string> GetTextFromServicesTitlesElements => ServicesTitlesElements.Select(x => x.GetText()).ToList();

        public enum Item
        {
            ContactUs
        }
    }
}
