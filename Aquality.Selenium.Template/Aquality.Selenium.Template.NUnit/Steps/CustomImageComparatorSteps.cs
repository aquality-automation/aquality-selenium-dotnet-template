using NUnit.Framework;
using Aquality.Selenium.Template.Utilities;
using System.Drawing;

namespace Aquality.Selenium.Template.NUnit.Steps
{
    public class CustomImageComparatorSteps : BaseSteps
    {
        private readonly CustomImageComparator customImageComparator;
        private readonly Image modelOfImage;

        public CustomImageComparatorSteps(float customThresholdValue, string modelImageResourses)
        {
            modelOfImage = Image.FromFile(modelImageResourses);
            var imageWidth = modelOfImage.Width;
            var imageHeight = modelOfImage.Height;
            customImageComparator = new CustomImageComparator(customThresholdValue, imageWidth, imageHeight);
        }

        public Image GetExpectedImageFromResourse(string expectedImageResourse)
        {
            LogStep();
            return Image.FromFile(expectedImageResourse);
        }

        public void CheckThatActualAndExpectedImagesAreTheSame(Image expectedImage)
        {
            LogAssertion();
            var differenceBetweenImages = customImageComparator.Compare(modelOfImage, expectedImage);
            Assert.AreEqual(0, differenceBetweenImages, "The images should be the same");
        }

        public void CheckThatActualAndExpectedImagesAreNotTheSame(Image expectedImage)
        {
            LogAssertion();
            var differenceBetweenImages = customImageComparator.Compare(modelOfImage, expectedImage);
            Assert.AreNotEqual(0, differenceBetweenImages, "The images should not be the same");
        }
    }
}
