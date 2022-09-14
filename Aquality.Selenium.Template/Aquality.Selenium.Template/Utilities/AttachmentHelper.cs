using Allure.Commons;
using AqualityTracking.Integrations.Core;
using Newtonsoft.Json;
using NUnit.Framework;
using System.IO;
using System.Text;

namespace Aquality.Selenium.Template.Utilities
{
    public static class AttachmentHelper
    {
        private const string JsonType = "application/json";

        public static void AddAttachment(string pathToFile, string name = null)
        {
            TestContext.AddTestAttachment(pathToFile);
            AllureLifecycle.Instance.AddAttachment(pathToFile, name);
            AqualityTrackingLifecycle.Instance.AddAttachment(pathToFile);
        }

        public static void AddAttachment(string name, string type, string content, string fileExtension = "")
        {
            var utfBytes = Encoding.UTF8.GetBytes(content);
            AllureLifecycle.Instance.AddAttachment(name, type, utfBytes, fileExtension);
            var filePath = name + fileExtension;
            File.WriteAllBytes(filePath, utfBytes);
            AqualityTrackingLifecycle.Instance.AddAttachment(filePath);
            if (fileExtension == ".json" || fileExtension == ".xml")
            {
                var filePathForAzurePreview = filePath + ".txt";
                File.Move(filePath, filePathForAzurePreview);
                filePath = filePathForAzurePreview;
            }
            
            TestContext.AddTestAttachment(filePath);
        }

        public static void AddAttachmentAsJson(string name, object content, NullValueHandling nullValueHandling = NullValueHandling.Include)
        {
            var json = JsonConvert.SerializeObject(content, Formatting.Indented,
                new JsonSerializerSettings { NullValueHandling = nullValueHandling });
            AddAttachment(name, JsonType, json, ".json");
        }
    }
}
