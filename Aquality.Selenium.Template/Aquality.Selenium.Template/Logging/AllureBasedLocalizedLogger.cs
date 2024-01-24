using Allure.Net.Commons;
using Aquality.Selenium.Core.Configurations;
using Aquality.Selenium.Core.Localization;
using Aquality.Selenium.Core.Logging;
using System;

namespace Aquality.Selenium.Template.Logging
{
    public class AllureBasedLocalizedLogger(ILocalizationManager localizationManager, Logger logger, ILoggerConfiguration configuration) : LocalizedLogger(localizationManager, logger, configuration), ILocalizedLogger
    {
        private readonly ILocalizationManager localizationManager = localizationManager;

        public new void InfoElementAction(string elementType, string elementName, string messageKey, params object[] args)
        {
            AddStepToAllure($"{elementType} '{elementName}' :: {localizationManager.GetLocalizedMessage(messageKey, args)}");
            base.InfoElementAction(elementType, elementName, messageKey, args);
        }

        public new void Info(string messageKey, params object[] args)
        {
            AddStepToAllure(localizationManager.GetLocalizedMessage(messageKey, args));
            base.Info(messageKey, args);
        }

        private void AddStepToAllure(string message)
        {
            var timeStamp = DateTime.Now.ToString("HH:mm:ss.fff");
            AllureLifecycle.Instance.WrapInStep(() => {}, $"{timeStamp} - {message}");
        }
    }
}
