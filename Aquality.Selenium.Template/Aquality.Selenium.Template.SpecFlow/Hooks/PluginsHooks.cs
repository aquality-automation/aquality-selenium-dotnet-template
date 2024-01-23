using Allure.Net.Commons;
using Aquality.Selenium.Browsers;
using Aquality.Selenium.Template.Browsers;
using AqualityTracking.Integrations.Core;
using NUnit.Framework;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;

namespace Aquality.Selenium.Template.SpecFlow.Hooks
{
    [Binding]
    public class PluginsHooks
    {
        public PluginsHooks()
        {
        }

        [BeforeFeature]
        public static void RegisterCustomStartup()
        {
            AqualityServices.SetStartup(new CustomStartup());
        }

        [AfterScenario(Order = -1)]
        public void UpdateAllureTestCaseName()
        {
            AllureLifecycle.Instance.UpdateTestCase(testCase =>
            {
                testCase.name += GetScenarioNameSuffix();
                testCase.historyId = TestContext.CurrentContext.Test.FullName;
            });
        }

        [BeforeScenario(Order = -1)]
        public void UpdateAqualityTrackingTestCaseName()
        {
            AqualityTrackingLifecycle.Instance.UpdateCurrentTest(test => test.Name += GetScenarioNameSuffix());
        }

        private string GetScenarioNameSuffix()
        {
            var suffix = string.Empty;
            var testFullName = TestContext.CurrentContext.Test.FullName;
            var paramsMatch = Regex.Match(testFullName, @"(.*)(\(.*\))$");
            if (paramsMatch.Success)
            {
                suffix = $" {paramsMatch.Groups[2].Value.Replace(",null", string.Empty)}";
            }
            return suffix;
        }
    }
}
