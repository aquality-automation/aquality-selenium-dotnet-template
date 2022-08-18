﻿using Aquality.Selenium.Browsers;
using Aquality.Selenium.Core.Logging;
using Aquality.Selenium.Template.Implementation;
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
            Logger.Info("Setup startup config");
            var customStartUp = new CustomStartUp();
            AqualityServices.SetStartup(customStartUp);
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

        [TearDown]
        public void CleanUp()
        {
            if (AqualityServices.IsBrowserStarted)
            {
                AqualityServices.Browser.Quit();
            }
        }

        public void SetScreenExpansionMaximize()
        {
            AqualityServices.Browser.Maximize();
        }

        public void GoToPageStartPage()
        {
            AqualityServices.Browser.GoTo(Configuration.Configuration.StartUrl);
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
