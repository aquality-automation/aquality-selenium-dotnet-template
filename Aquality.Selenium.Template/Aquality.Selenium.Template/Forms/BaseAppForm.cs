using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace Aquality.Selenium.Template.Forms
{
    public class BaseAppForm : Form
    {
        private IButton AcceptCookiesBtn => ElementFactory.GetButton(By.Id("cookie_action_close_header"), "Accept cookies");

        protected BaseAppForm(By locator, string name) : base(locator, name)
        {
        }

        public void AcceptCookies()
        {
            AcceptCookiesBtn.Click();
        }
    }
}
