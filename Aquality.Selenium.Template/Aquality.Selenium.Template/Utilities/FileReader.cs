using Newtonsoft.Json;
using System.IO;

namespace Aquality.Selenium.Template.Utilities
{
    public static class FileReader
    {
        public static T ReadJsonData<T>(string path)
        {
            return JsonConvert.DeserializeObject<T>(ReadFile(path));
        }

        private static string ReadFile(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                return sr.ReadToEnd();
            }
        }
    }
}