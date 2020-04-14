using Aquality.Selenium.Browsers;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Aquality.Selenium.Template.Utilities
{
    public class ScreenshotProvider
    {
        public void TakeScreenshot(string name)
        {
            var image = GetImage();
            var directory = Path.Combine(Environment.CurrentDirectory, "screenshots");
            EnsureDirectoryExists(directory);
            image.Save(Path.Combine(directory, name), ImageFormat.Png);
        }

        private Image GetImage()
        {
            using (var stream = new MemoryStream(AqualityServices.Browser.GetScreenshot()))
            {
                return Image.FromStream(stream);
            }
        }

        private static void EnsureDirectoryExists(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }
    }
}
