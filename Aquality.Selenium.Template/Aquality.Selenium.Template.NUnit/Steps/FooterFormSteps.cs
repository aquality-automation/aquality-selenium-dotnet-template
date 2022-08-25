using Aquality.Selenium.Template.Forms;
using Aquality.Selenium.Template.NUnit.Extensions;
using NUnit.Framework;

namespace Aquality.Selenium.Template.NUnit.Steps
{
    public class FooterFormSteps : BaseSteps
    {
        private readonly FooterForm footerForm = new FooterForm();

        public void FooterFormIsPresent()
        {
            LogAssertion();
            footerForm.AssertIsPresent();
        }

        public void CheckVisualElementsPresent()
        {
            LogAssertion();
            Assert.Multiple(() =>
            {
                Assert.IsTrue(footerForm.IsLogoPresent, "Logo should be displayed");
                Assert.IsTrue(footerForm.IsContactsPresent, "Contacts section should be displayed");
                Assert.IsTrue(footerForm.IsSubscribePresent, "Subscribe section should be displayed");
            });
        }

        public void SaveDump()
        {
            LogStep();
            footerForm.Dump.Save();
        }

        public void CheckThatTheVisualElementsAreCorrect()
        {
            LogAssertion();
            var compareVisualElements = footerForm.Dump.Compare();
            Assert.AreEqual(0, compareVisualElements, "The footer form should contain the correct visual elements");
        }
    }
}
