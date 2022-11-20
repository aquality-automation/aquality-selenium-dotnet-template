using Aquality.Selenium.Template.Forms;
using Aquality.Selenium.Template.NUnit.Extensions;
using NUnit.Framework;
using Aquality.Selenium.Template.CustomAttributes;

namespace Aquality.Selenium.Template.NUnit.Steps
{
    public class TopBarMenuSteps
    {
        private readonly TopBarMenu topBarMenu = new TopBarMenu();
        private const string ServicesTabItem = "Services";
        private readonly string[] headerTabItems = { "Services", "Approach", "Portfolio", "Blog", "Company" };
        private readonly string[] servicesTitleElements = { "Full-cycle testing services", "Quality engineering", "Complete test coverage", "Systems & platforms" };

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
            Assert.IsTrue(topBarMenu.IsContactUsButtonExist);
        }

        [LogStep(StepType.Assertion)]
        public void CheckThatNavigationElementsAreCorrect()
        {
            var headerNavigationElements = topBarMenu.GetTextForHeaderNavigationElements;
            CollectionAssert.AreEquivalent(headerTabItems, headerNavigationElements, "Header navigation elements should be correct");
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
            CollectionAssert.AreEqual(servicesTitleElements, servicesTitlesElements, "Services title elements should be correct");
        }
    }
}
