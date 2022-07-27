using Aquality.Selenium.Forms;
using NUnit.Framework;

namespace Aquality.Selenium.Template.NUnit.Extensions
{
    public static class FormExtensions
    {
        public static void AssertIsPresent(this Form form)
        {
            Assert.IsTrue(form.State.WaitForDisplayed(), $"{form.Name} should be presented");
        }

        public static void AssertIsNotPresent(this Form form)
        {
            Assert.IsTrue(form.State.WaitForNotDisplayed(), $"{form.Name} should be presented");
        }
    }
}
