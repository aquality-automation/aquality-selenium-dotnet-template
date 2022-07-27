using OpenQA.Selenium;
using static Aquality.Selenium.Browsers.AqualityServices;

namespace Aquality.Selenium.Template.Utilities
{
    public static class BrowserUtils
    {
        public static void OpenInNewTabAndSwitch(string url)
        {
            OpenInNewTab(url);
            SwitchToLastTab();
        }

        public static void OpenInNewTab(string url) => Browser.Tabs().OpenInNewTab(url);

        public static void SwitchToLastTab() => Browser.Tabs().SwitchToLastTab();

        public static void CloseCurrentTab() => Browser.Tabs().CloseTab();

        public static void SwitchToTheFirstTab() => Browser.Tabs().SwitchToTab(0);

        public static void RefreshPage() => Browser.Refresh();

        public static string GetCurrentWindowName() => Browser.Driver.CurrentWindowHandle;

        public static object ExecuteScript(string script) => Browser.Driver.ExecuteScript(script);

        public static void SwitchToDefaultContent() => Browser.Driver.SwitchTo().DefaultContent();

        public static void ScrollWindowBy(int x, int y) => Browser.ScrollWindowBy(x, y);

        public static string GetCurrentUrl() => Browser.CurrentUrl;

        public static void AddСookiesByKey(string key, string value) => Browser.Driver.Manage().Cookies.AddCookie(new Cookie(key, value));
    }
}