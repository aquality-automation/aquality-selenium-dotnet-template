using Aquality.Selenium.Browsers;
using Aquality.Selenium.Core.Applications;
using Aquality.Selenium.Core.Configurations;
using Aquality.Selenium.Core.Localization;
using Aquality.Selenium.Template.Configurations;
using Aquality.Selenium.Template.Logging;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Aquality.Selenium.Template.Browsers
{
    public class CustomStartup : BrowserStartup
    {
        public override IServiceCollection ConfigureServices(IServiceCollection services, Func<IServiceProvider, IApplication> applicationProvider, ISettingsFile settings = null)
        {
            settings = settings ?? GetSettings();
            base.ConfigureServices(services, applicationProvider, settings);
            services.AddSingleton<ILocalizedLogger, AllureBasedLocalizedLogger>();
            services.AddSingleton<ICustomTimeoutConfiguration, CustomTimeoutConfiguration>();
            return services;
        }
    }
}
