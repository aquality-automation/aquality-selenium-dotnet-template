using Microsoft.Extensions.DependencyInjection;
using System;
using Aquality.Selenium.Core.Applications;
using Aquality.Selenium.Core.Configurations;
using Aquality.Selenium.Browsers;
using Aquality.Selenium.Template.Interfaces;

namespace Aquality.Selenium.Template.CustomConfigImplementation
{
    public class CustomStartUp : BrowserStartup
    {
        public override IServiceCollection ConfigureServices(IServiceCollection services, Func<IServiceProvider, IApplication> applicationProvider,
            ISettingsFile settings = null)
        {
            settings = settings ?? GetSettings();
            base.ConfigureServices(services, applicationProvider, settings);
            services.AddSingleton<ICustomTimeoutConfiguration, CustomTimeoutConfiguration>();
            return services;
        }
    }
}
