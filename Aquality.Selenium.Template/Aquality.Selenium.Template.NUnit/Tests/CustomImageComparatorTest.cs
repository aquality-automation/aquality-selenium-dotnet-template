using Aquality.Selenium.Template.NUnit.Constants;
using Aquality.Selenium.Template.Utilities;
using NUnit.Framework;
using System.Drawing;

namespace Aquality.Selenium.Template.NUnit.Tests
{
    public class CustomImageComparatorTest : BaseTest
    {
        [Test(Description = "TC-0005 Check Custom Image Comparator")]
        public void TC0005_CheckCustomImageComparator()
        {
            CustomImageComparator.Init();

            var firstImage = Image.FromFile(PathConstants.FirstTestImage);

            var secondImage = Image.FromFile(PathConstants.SecondTestImage);

            var compareResult = CustomImageComparator.Compare(firstImage, secondImage);

            Assert.AreEqual(compareResult, 0, "The images should be the same");
        }
    }
}
