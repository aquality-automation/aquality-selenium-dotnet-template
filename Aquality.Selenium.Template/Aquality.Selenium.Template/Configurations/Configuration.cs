namespace Aquality.Selenium.Template.Configurations
{
    public static class Configuration
    {
        public static string StartUrl => Environment.CurrentEnvironment.GetValue<string>(".startUrl");

        public static string ApiUrl => Environment.CurrentEnvironment.GetValue<string>(".apiUrl");
    }
}
