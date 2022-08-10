using Aquality.Selenium.Configurations;
using System;

namespace Aquality.Selenium.Template.Interfaces
{
    public interface ICustomTimeoutConfiguration : ITimeoutConfiguration
    {
        public TimeSpan ElementAppear { get; }
    }
}
