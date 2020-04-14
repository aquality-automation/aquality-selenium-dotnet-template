using OpenQA.Selenium;

namespace Aquality.Selenium.Template.Forms.Pages
{
    public class MainPage : BaseAppForm
    {
        public MainPage() : base(By.XPath("//section[@class='testing-services-block']"), "Main page")
        {
        }
    }
}
