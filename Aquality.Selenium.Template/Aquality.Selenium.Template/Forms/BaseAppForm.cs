using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace Aquality.Selenium.Template.Forms
{
    public class BaseAppForm : Form
    {
        private IButton AcceptCookiesBtn => ElementFactory.GetButton(By.ClassName("cookies__button"), "Accept cookies");

        protected BaseAppForm(By locator, string name) : base(locator, name)
        {
        }

        public void AcceptCookies() => AcceptCookiesBtn.Click();
    }
}
