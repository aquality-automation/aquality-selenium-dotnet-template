using NUnit.Framework;
using Aquality.Selenium.Template.Utilities;
using System.Drawing;
using Aquality.Selenium.Template.CustomAttributes;
using System.Diagnostics.CodeAnalysis;

namespace Aquality.Selenium.Template.NUnit.Steps
{
    [SuppressMessage("Interoperability", "CA1416:Validate platform compatibility", Justification = "<Pending>")]
    public class CustomImageComparatorSteps
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

        [LogStep(StepType.Step)]
        public static Image GetExpectedImageFromResourse(string expectedImageResourse)
        {
            return Image.FromFile(expectedImageResourse);
        }

        [LogStep(StepType.Assertion)]
        public void CheckThatActualAndExpectedImagesAreTheSame(Image expectedImage)
        {
            var differenceBetweenImages = customImageComparator.Compare(modelOfImage, expectedImage);
            Assert.AreEqual(0, differenceBetweenImages, "The images should be the same");
        }

        [LogStep(StepType.Assertion)]
        public void CheckThatActualAndExpectedImagesAreNotTheSame(Image expectedImage)
        {
            var differenceBetweenImages = customImageComparator.Compare(modelOfImage, expectedImage);
            Assert.AreNotEqual(0, differenceBetweenImages, "The images should not be the same");
        }
    }
}
