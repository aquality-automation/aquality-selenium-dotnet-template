using Aquality.Selenium.Template.CustomAttributes;
using Aquality.Selenium.Template.Forms;
using Aquality.Selenium.Template.NUnit.Extensions;
using NUnit.Framework;

namespace Aquality.Selenium.Template.NUnit.Steps
{
    public class FooterFormSteps
    {
        private readonly FooterForm footerForm = new();
        const float ComparisonThreshold = 0.1f;

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
                Assert.That(footerForm.IsLogoPresent, "Logo should be displayed");
                Assert.That(footerForm.IsContactsPresent, "Contacts section should be displayed");
                Assert.That(footerForm.IsSubscribePresent, "Subscribe section should be displayed");
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
            Assert.That(compareVisualElements, Is.LessThanOrEqualTo(ComparisonThreshold), "The footer form should contain the correct visual elements");
        }
    }
}
