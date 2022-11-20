using Aquality.Selenium.Template.NUnit.Constants;
using Aquality.Selenium.Template.NUnit.Steps;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;

namespace Aquality.Selenium.Template.NUnit.Tests
{
    [AllureNUnit]
    [AllureSuite("CustomImageComparatorTest")]
    public class CustomImageComparatorTest : BaseTest
    {
        const float CustomThresholdValue = 0.1f;
        private readonly CustomImageComparatorSteps customImageComparatorSteps = new CustomImageComparatorSteps(CustomThresholdValue, ResourceConstants.ActualTestImage);


        [Test(Description = "TC-0005 Compare 2 images one of which is different")]
        public void TC0005_Compare2ImagesOneOfWhichIsDifferent()
        {
            var expectedImage = customImageComparatorSteps.GetExpectedImageFromResourse(ResourceConstants.ExpectedIncorrectImage);
            customImageComparatorSteps.CheckThatActualAndExpectedImagesAreNotTheSame(expectedImage);
        }


        [Test(Description = "TC-0006 Compare 2 images when both images are the same")]
        public void TC0006_Compare2ImagesWhenBothImagesAreTheSame()
        {
            var expectedImage = customImageComparatorSteps.GetExpectedImageFromResourse(ResourceConstants.ExpectedCorrectImage);
            customImageComparatorSteps.CheckThatActualAndExpectedImagesAreTheSame(expectedImage);
        }
    }
}
