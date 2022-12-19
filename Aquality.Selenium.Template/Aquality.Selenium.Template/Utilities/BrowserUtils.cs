using OpenQA.Selenium;
using static Aquality.Selenium.Browsers.AqualityServices;

namespace Aquality.Selenium.Template.Utilities
{
    public static class BrowserUtils
    {
        public static void AddСookiesByKey(string key, string value) => Browser.Driver.Manage().Cookies.AddCookie(new Cookie(key, value));
    }
}
