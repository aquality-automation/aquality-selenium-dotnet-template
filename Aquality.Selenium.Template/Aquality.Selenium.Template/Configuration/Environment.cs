using Aquality.Selenium.Browsers;
using Aquality.Selenium.Core.Configurations;
using Aquality.Selenium.Core.Utilities;
using System.Reflection;

namespace Aquality.Selenium.Template.Configuration
{
    internal static class Environment
    {
        private const string EnvironmentVariableKey = "environment";

        public static ISettingsFile CurrentEnvironment
        {
            get
            {
                var defaultEnvName = AqualityServices.Get<ISettingsFile>().GetValue<string>(EnvironmentVariableKey);
                var envName = EnvironmentConfiguration.GetVariable(EnvironmentVariableKey) ?? defaultEnvName; 
                var pathToConfigFile = $"Resources.Environment.{envName}.config.json";
                return new JsonSettingsFile(pathToConfigFile, Assembly.GetCallingAssembly());
            }
        }
    }
}
