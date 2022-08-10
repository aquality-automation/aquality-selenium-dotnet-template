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
            var firstImage = Image.FromFile(ResourceConstants.FirstTestImage);

            var firstImageWidth = firstImage.Width;

            var firstImageHeight = firstImage.Height;

            var secondImage = Image.FromFile(ResourceConstants.SecondTestImage);

            var customImageComparator = new CustomImageComparator(0.1f, firstImageWidth, firstImageHeight);

            var differenceBetweenImages = customImageComparator.Compare(firstImage, secondImage);

            Assert.AreEqual(0, differenceBetweenImages, "The images should be the same");
        }
    }
}
