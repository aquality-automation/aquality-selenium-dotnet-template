using Aquality.Selenium.Template.NUnit.Constants;
using Aquality.Selenium.Template.Utilities;
using NUnit.Framework;
using System.Drawing;

namespace Aquality.Selenium.Template.NUnit.Tests
{
    public class CustomImageComparatorTest : BaseTest
    {
        const float TheThresholdValueOf10Percent = 0.1f;

        [Test(Description = "TC-0005 Comparison of two given images")]
        public void TC0005_ComparisonOfTwoGivenImages()
        {
            var firstImage = Image.FromFile(ResourceConstants.FirstTestImage);

            var firstImageWidth = firstImage.Width;

            var firstImageHeight = firstImage.Height;

            var secondImage = Image.FromFile(ResourceConstants.SecondTestImage);

            var customImageComparator = new CustomImageComparator(TheThresholdValueOf10Percent, firstImageWidth, firstImageHeight);

            var differenceBetweenImages = customImageComparator.Compare(firstImage, secondImage);

            Assert.AreNotEqual(0, differenceBetweenImages, "The images should not be the same");
        }
    }
}
