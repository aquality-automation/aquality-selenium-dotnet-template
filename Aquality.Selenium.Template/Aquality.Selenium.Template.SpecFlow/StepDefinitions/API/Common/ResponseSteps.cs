using NUnit.Framework;
using RestSharp;
using TechTalk.SpecFlow;

namespace Aquality.Selenium.Template.SpecFlow.StepDefinitions.API.Common
{
    [Binding]
    public class ResponseSteps
    {
        [Then(@"the status code of the '(.*response.*)' is '(\d*)'")]
        public static void StatusCodeOfResponseIs(RestResponse response, int statusCode)
        {
            Assert.That((int)response.StatusCode, Is.EqualTo(statusCode), "Status code should match to expected");
        }
    }
}
