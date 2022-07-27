using OpenQA.Selenium;

namespace Aquality.Selenium.Template.Forms.Pages
{
    public class MainPage : BaseAppForm
    {
        public MainPage() : base(By.XPath("//section[@class='heroMain heroMain--video-paused']"), "Main page")
        {
        }
    }
}
