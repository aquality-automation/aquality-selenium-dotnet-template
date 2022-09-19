using Aquality.Selenium.Template.Models;
using Aquality.Selenium.Template.Utilities;
using NUnit.Framework;
using RestSharp;
using TechTalk.SpecFlow;

namespace Aquality.Selenium.Template.SpecFlow.StepDefinitions.API.GitHub
{
    [Binding]
    public class UserSteps
    {
        private readonly ScenarioContext scenarioContext;

        public UserSteps(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }


        [When(@"I save the user from the '(.*response.*)' as '(.*)'")]
        public void SaveTheUserFromTheResponse(RestResponse response, string key)
        {
            scenarioContext.Add(key, response.GetBodyAs<User>());
        }

        [Then(@"User '(.*)' is different from the user '(.*)'")]
        public void CheckUsersAreDifferent(string user1Key, string user2Key)
        {
            var user1 = scenarioContext.Get<User>(user1Key);
            var user2 = scenarioContext.Get<User>(user2Key);
            Assert.AreNotEqual(user1, user2, "Users should not be equal");
        }
    }
}
