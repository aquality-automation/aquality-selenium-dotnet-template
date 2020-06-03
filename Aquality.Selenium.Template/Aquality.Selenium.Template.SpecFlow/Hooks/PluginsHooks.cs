using Allure.Commons;
using AqualityTracking.SpecFlowPlugin;
using NUnit.Framework;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;

namespace Aquality.Selenium.Template.SpecFlow.Hooks
{
    [Binding]
    public class PluginsHooks
    {
        private readonly ScenarioContext context;

        public PluginsHooks(ScenarioContext context)
        {
            this.context = context;
        }

        [AfterScenario(Order = -1)]
        public void UpdateAllureTestCaseName()
        {
            context.TryGetValue(out TestResult testresult);
            AllureLifecycle.Instance.UpdateTestCase(testresult.uuid, testCase =>
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
