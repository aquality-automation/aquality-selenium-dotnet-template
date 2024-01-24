using Aquality.Selenium.Core.Elements;
using Aquality.Selenium.Elements;
using OpenQA.Selenium;

namespace Aquality.Selenium.Template.Elements
{
    public class CustomTextBox(By locator, string name, ElementState state) : TextBox(locator, name, state)
    {
        public new string Text => Value;
    }
}
