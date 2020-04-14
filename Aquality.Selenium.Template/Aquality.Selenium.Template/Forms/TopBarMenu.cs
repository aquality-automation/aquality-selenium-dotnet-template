using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace Aquality.Selenium.Template.Forms
{
    public class TopBarMenu : Form
    {
        private static readonly IDictionary<Item, string> menuItems = new Dictionary<Item, string>
        {
            { Item.ContactUs, "//div[@id='primary-navigation']//li[contains(@class, 'contact-us menu')]//a" }
        };

        public TopBarMenu() : base(By.Id("masthead"), "Header")
        {
        }

        public void OpenHeaderMenu(Item menuItem) => ElementFactory.GetButton(By.XPath(menuItems[menuItem]), menuItem.ToString()).ClickAndWait();

        public enum Item
        {
            ContactUs
        }
    }
}
