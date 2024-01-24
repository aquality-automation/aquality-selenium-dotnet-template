using NUnit.Framework;
using Aquality.Selenium.Template.Utilities;
using Aquality.Selenium.Template.CustomAttributes;
using SkiaSharp;
using System.IO;
using Aquality.Selenium.Core.Visualization;

namespace Aquality.Selenium.Template.NUnit.Steps
{
    public class CustomImageComparatorSteps
    {
        private readonly CustomImageComparator customImageComparator;
        private readonly SKImage modelOfImage;

        public CustomImageComparatorSteps(float customThresholdValue, string modelImageResourses)
        {
            modelOfImage = new FileInfo(modelImageResourses).ReadImage();
            var imageWidth = modelOfImage.Width;
            var imageHeight = modelOfImage.Height;
            customImageComparator = new CustomImageComparator(customThresholdValue, imageWidth, imageHeight);
        }

        [LogStep(StepType.Step)]
        public static SKImage GetExpectedImageFromResourse(string expectedImageResourse)
        {
            AttachmentHelper.AddAttachment(expectedImageResourse);
            return new FileInfo(expectedImageResourse).ReadImage();
        }

        [LogStep(StepType.Assertion)]
        public void CheckThatActualAndExpectedImagesAreTheSame(SKImage expectedImage)
        {
            var differenceBetweenImages = customImageComparator.Compare(modelOfImage, expectedImage);
            Assert.That(differenceBetweenImages, Is.Zero, "The images should be the same");
        }

        [LogStep(StepType.Assertion)]
        public void CheckThatActualAndExpectedImagesAreNotTheSame(SKImage expectedImage)
        {
            var differenceBetweenImages = customImageComparator.Compare(modelOfImage, expectedImage);
            Assert.That(differenceBetweenImages, Is.Not.Zero, "The images should not be the same");
        }
    }
}
