using System.IO;

namespace Aquality.Selenium.Template.NUnit.Constants
{
    public static class ResourceConstants
    {
        public static string PathToContactUserWithInvalidEmail => @"Resources.TestData.ContactUserWithInvalidEmail.json";
        public static string PathToGetFullPageHeightJS => @"Resources.JavaScripts.GetFullPageHeight.js";
        public static string ActualTestImage => Path.Combine("Resources", "ImagesForVisualTesting", "ActualTestImage.jpg");
        public static string ExpectedCorrectImage => Path.Combine("Resources", "ImagesForVisualTesting", "ExpectedCorrectImage.jpg");
        public static string ExpectedIncorrectImage => Path.Combine("Resources", "ImagesForVisualTesting", "ExpectedIncorrectImage.jpg");
    }
}
