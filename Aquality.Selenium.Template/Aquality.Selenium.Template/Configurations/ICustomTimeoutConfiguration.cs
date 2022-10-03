using Aquality.Selenium.Configurations;
using System;

namespace Aquality.Selenium.Template.Configurations
{
    public interface ICustomTimeoutConfiguration : ITimeoutConfiguration
    {
        public TimeSpan ElementAppear { get; }
    }
}
