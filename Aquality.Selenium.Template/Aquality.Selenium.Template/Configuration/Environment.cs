using Aquality.Selenium.Core.Configurations;
using Aquality.Selenium.Core.Utilities;
using System.Reflection;

namespace Aquality.Selenium.Template.Configuration
{
    internal static class Environment
    {
        public static ISettingsFile CurrentEnvironment
        {
            get
            {
                var envName = EnvironmentConfiguration.GetVariable("environment") ?? "Stage";
                var pathToConfigFile = $"Resources.Environment.{envName}.config.json";
                return new JsonSettingsFile(pathToConfigFile, Assembly.GetCallingAssembly());
            }
        }
    }
}
