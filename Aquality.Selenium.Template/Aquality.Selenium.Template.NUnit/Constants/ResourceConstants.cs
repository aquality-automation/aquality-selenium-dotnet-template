using System.IO;

namespace Aquality.Selenium.Template.NUnit.Constants
{
    public static class ResourceConstants
    {
        public static string PathToContactUserWithInvalidEmail = @"Resources.TestData.ContactUserWithInvalidEmail.json";
        public static string PathToGetFullPageHeightJS = @"Resources.JavaScripts.GetFullPageHeight.js";
        public static string ActualTestImage => Path.Combine("Resources", "ImagesForCustomImageComparator", "ActualTestImage.jpg");
        public static string ExpectedCorrectImage = Path.Combine("Resources", "ImagesForCustomImageComparator", "ExpectedCorrectImage.jpg");
        public static string ExpectedIncorrectImage = Path.Combine("Resources", "ImagesForCustomImageComparator", "ExpectedIncorrectImage.jpg");
    }
}
