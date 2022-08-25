using Aquality.Selenium.Template.Forms;
using Aquality.Selenium.Template.NUnit.Extensions;
using NUnit.Framework;

namespace Aquality.Selenium.Template.NUnit.Steps
{
    public class TopBarMenuSteps : BaseSteps
    {
        private readonly TopBarMenu topBarMenu = new TopBarMenu();
        private const string ServicesTabItem = "Services";
        private readonly string[] headerTabItems = { "Services", "Approach", "Portfolio", "Blog", "Company" };
        private readonly string[] servicesTitleElements = { "Full-cycle testing services", "Quality engineering", "Complete test coverage", "Systems & platforms" };

        public void TopBarMenuIsPresent()
        {
            LogAssertion();
            topBarMenu.AssertIsPresent();
        }

        public void ClickContactUs()
        {
            LogStep();
            topBarMenu.ClickContactUs();
        }

        public void ContactUsButtonIsPresent()
        {
            LogAssertion();
            Assert.IsTrue(topBarMenu.IsContactUsButtonExist);
        }

        public void CheckThatNavigationElementsAreCorrect()
        {
            LogAssertion();
            var headerNavigationElements = topBarMenu.GetTextForHeaderNavigationElements;
            CollectionAssert.AreEquivalent(headerTabItems, headerNavigationElements, "Header navigation elements should be correct");
        }

        public void MoveToTheServicesNavigationTab()
        {
            LogStep();
            topBarMenu.MoveToTheTabButton(ServicesTabItem);
        }

        public void CheckThatServicesTitlesAreDispalayedAndCorrect()
        {
            LogAssertion();
            var servicesTitlesElements = topBarMenu.GetTextFromServicesTitlesElements;
            CollectionAssert.AreEqual(servicesTitleElements, servicesTitlesElements, "Services title elements should be correct");
        }
    }
}
