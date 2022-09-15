using Aquality.Selenium.Template.Utilities;
using RestSharp;
using TechTalk.SpecFlow;

namespace Aquality.Selenium.Template.SpecFlow.StepDefinitions.API.GitHub
{
    [Binding]
    public class RequestSteps
    {
        private readonly RequestHandler requestHandler;
        private readonly ScenarioContext scenarioContext;

        public RequestSteps(RequestHandler requestHandler, ScenarioContext scenarioContext)
        {
            this.requestHandler = requestHandler;
            this.scenarioContext = scenarioContext;
        }


        [When(@"I send GET '/([\w-/]+)' request to github and save the '(.*response.*)'")]
        [When(@"I send GET request to github endpoint saved as '(.*)' and save the '(.*response.*)'")]
        public void SendGetRequestToGitHubAndSaveResponse(string endpoint, string contextKey)
        {
            if (scenarioContext.ContainsKey(endpoint))
            {
                endpoint = scenarioContext.Get<string>(endpoint);
            }
            var response = requestHandler.Execute(new RestRequest(endpoint, Method.Get));
            scenarioContext.Add(contextKey, response);
        }
    }
}
