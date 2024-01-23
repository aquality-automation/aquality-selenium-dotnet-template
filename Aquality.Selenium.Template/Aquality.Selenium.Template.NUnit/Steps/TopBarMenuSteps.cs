using Aquality.Selenium.Template.Forms;
using Aquality.Selenium.Template.NUnit.Extensions;
using NUnit.Framework;
using Aquality.Selenium.Template.CustomAttributes;

namespace Aquality.Selenium.Template.NUnit.Steps
{
    public class TopBarMenuSteps
    {
        private readonly TopBarMenu topBarMenu = new();
        private const string ServicesTabItem = "Services";
        private static readonly string[] HeaderTabItems = { "Services", "Industries", "Approach", "Portfolio", "Blog", "Company" };
        private static readonly string[] ServicesTitleElements = { "Full-cycle testing services", "Quality engineering", "Complete test coverage", "Systems & platforms" };

        [LogStep(StepType.Assertion)]
        public void TopBarMenuIsPresent()
        {
            topBarMenu.AssertIsPresent();
        }

        [LogStep(StepType.Step)]
        public void ClickContactUs()
        {
            topBarMenu.ClickContactUs();
        }

        [LogStep(StepType.Assertion)]
        public void ContactUsButtonIsPresent()
        {
            Assert.IsTrue(topBarMenu.IsContactUsButtonExist, "Contact Us button should be present");
        }

        [LogStep(StepType.Assertion)]
        public void CheckThatNavigationElementsAreCorrect()
        {
            var headerNavigationElements = topBarMenu.GetTextForHeaderNavigationElements;
            CollectionAssert.AreEquivalent(HeaderTabItems, headerNavigationElements, "Header navigation elements should be correct");
        }

        [LogStep(StepType.Step)]
        public void MoveToTheServicesNavigationTab()
        {
            topBarMenu.MoveToTheTabButton(ServicesTabItem);
        }

        [LogStep(StepType.Assertion)]
        public void CheckThatServicesTitlesAreDispalayedAndCorrect()
        {
            var servicesTitlesElements = topBarMenu.GetTextFromServicesTitlesElements;
            CollectionAssert.AreEqual(ServicesTitleElements, servicesTitlesElements, "Services title elements should be correct");
        }
    }
}
