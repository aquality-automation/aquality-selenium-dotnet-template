using Aquality.Selenium.Template.CustomAttributes;
using Aquality.Selenium.Template.Forms;
using Aquality.Selenium.Template.NUnit.Extensions;
using NUnit.Framework;

namespace Aquality.Selenium.Template.NUnit.Steps
{
    public class FooterFormSteps
    {
        private readonly FooterForm footerForm = new FooterForm();
        const float ComparisonThreshold = 0.08f;

        [LogStep(StepType.Assertion)]
        public void FooterFormIsPresent()
        {
            footerForm.AssertIsPresent();
        }

        [LogStep(StepType.Assertion)]
        public void CheckVisualElementsPresent()
        {
            Assert.Multiple(() =>
            {
                Assert.IsTrue(footerForm.IsLogoPresent, "Logo should be displayed");
                Assert.IsTrue(footerForm.IsContactsPresent, "Contacts section should be displayed");
                Assert.IsTrue(footerForm.IsSubscribePresent, "Subscribe section should be displayed");
            });
        }

        [LogStep(StepType.Step)]
        public void SaveDump()
        {
            footerForm.Dump.Save();
        }

        [LogStep(StepType.Assertion)]
        public void CheckThatTheVisualElementsAreCorrect()
        {
            var compareVisualElements = footerForm.Dump.Compare();
            Assert.LessOrEqual(compareVisualElements, ComparisonThreshold, "The footer form should contain the correct visual elements");
        }
    }
}
