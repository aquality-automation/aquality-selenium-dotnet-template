using Aquality.Selenium.Browsers;
using Aquality.Selenium.Core.Configurations;
using Aquality.Selenium.Core.Utilities;
using System.Reflection;

namespace Aquality.Selenium.Template.Configurations
{
    internal static class Environment
    {
        public static ISettingsFile CurrentEnvironment
        {
            get
            {
                var envName = AqualityServices.Get<ISettingsFile>().GetValue<string>("environment");
                var pathToConfigFile = $"Resources.Environment.{envName}.config.json";
                return new JsonSettingsFile(pathToConfigFile, Assembly.GetCallingAssembly());
            }
        }
    }
}
