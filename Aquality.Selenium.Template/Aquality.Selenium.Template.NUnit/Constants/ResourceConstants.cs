using System.IO;

namespace Aquality.Selenium.Template.NUnit.Constants
{
    public static class ResourceConstants
    {
        public static string PathToContactUserWithInvalidEmail = @"Resources.TestData.ContactUserWithInvalidEmail.json";
        public static string PathToGetFullPageHeightJS = @"Resources.JavaScripts.GetFullPageHeight.js";
        public static string ActualTestImage => Path.Combine("Resources", "ImagesForCustomImageComparator", "actual_test_image.jpg");
        public static string ExpectedCorrectImage = Path.Combine("Resources", "ImagesForCustomImageComparator", "expected_correct_image.jpg");
        public static string ExpectedIncorrectImage = Path.Combine("Resources", "ImagesForCustomImageComparator", "expected_incorrect_image.jpg");
    }
}
