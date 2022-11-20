using Allure.Commons;
using Aquality.Selenium.Browsers;
using Aquality.Selenium.Core.Logging;
using Aquality.Selenium.Template.Browsers;
using Humanizer;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace Aquality.Selenium.Template.NUnit.Tests
{
    public abstract class BaseTest
    {
        protected string ScenarioName
            => TestContext.CurrentContext.Test.Properties.Get("Description")?.ToString()
            ?? TestContext.CurrentContext.Test.Name.Replace("_", string.Empty).Humanize();

        private static Logger Logger => Logger.Instance;

        private TestContext.ResultAdapter Result => TestContext.CurrentContext.Result;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Logger.Info("AllureLifecycle CleanupResultDirectory");
            AllureLifecycle.Instance.CleanupResultDirectory();
            Logger.Info("Setup startup config");
            AqualityServices.SetStartup(new CustomStartup());
        }

        [SetUp]
        public void Setup()
        {
            Logger.Info($"Start scenario [{ScenarioName}]");
        }

        [TearDown]
        public virtual void AfterEach()
        {
            LogScenarioResult();
        }

        private void LogScenarioResult()
        {
            Logger.Info($"Scenario [{ScenarioName}] result is {Result.Outcome.Status}!");
            if (Result.Outcome.Status != TestStatus.Passed)
            {
                Logger.Error(Result.Message);
            }
            Logger.Info(new string('=', 100));
        }
    }
}
