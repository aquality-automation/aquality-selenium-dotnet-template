using Aquality.Selenium.Core.Elements;
using Aquality.Selenium.Elements;
using OpenQA.Selenium;

namespace Aquality.Selenium.Template.Elements
{
    public class CustomTextBox : TextBox
    {
        public CustomTextBox(By locator, string name, ElementState state) : base(locator, name, state)
        {
        }

        public new string Text => Value;
    }
}
