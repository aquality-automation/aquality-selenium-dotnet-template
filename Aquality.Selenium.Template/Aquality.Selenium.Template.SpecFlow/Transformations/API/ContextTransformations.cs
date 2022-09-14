using RestSharp;
using System;
using TechTalk.SpecFlow;

namespace Aquality.Selenium.Template.SpecFlow.Transformations.API
{
    [Binding]
    public class ContextTransformations
    {
        private readonly ScenarioContext scenarioContext;

        public ContextTransformations(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }

        [StepArgumentTransformation("(.*response.*)")]
        public RestResponse Response(string key)
        {
            return scenarioContext.ContainsKey(key)
                ? scenarioContext.Get<RestResponse>(key)
                : throw new ArgumentException($"No response is stored in the context with name [{key}]");
        }
    }
}
