using Aquality.Selenium.Template.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TechTalk.SpecFlow;

namespace Aquality.Selenium.Template.SpecFlow.StepDefinitions.API.Common
{
    [Binding]
    public class ResponseSteps(ScenarioContext scenarioContext)
    {
        private readonly ScenarioContext scenarioContext = scenarioContext;

        [Then(@"the status code of the '(.*response.*)' is '(\d*)'")]
        public static void StatusCodeOfResponseIs(RestResponse response, int statusCode)
        {
            Assert.That((int)response.StatusCode, Is.EqualTo(statusCode), "Status code should match to expected");
        }

        [Then(@"the '(.*)' has the value saved as '(.*)' in the '(.*response.*)'")]
        public void CheckFieldInResponse(string fieldName, string valueKey, RestResponse response)
        {
            CheckFieldInResponse(fieldName, scenarioContext.Get<object>(valueKey), response);
        }

        [Then(@"the '(.*)' is '(.*)' in the '(.*response.*)'")]
        [Then(@"the '(.*)' is (\d*) in the '(.*response.*)'")]
        public static void CheckFieldInResponse(string fieldName, object expectedValue, RestResponse response)
        {
            var expectedAsString = expectedValue.ToString();
            Assert.That(response.ExtractPath(fieldName), Is.EqualTo(expectedAsString), $"Field '{fieldName}' should have value [{expectedValue}] in the response");
        }

        [Then(@"the '(.*response.*)' matches json schema '(.*)'")]
        public static void AssertResponseSchemaIsValid(RestResponse response, string schemaName)
        {
            var schemaPath = Path.Combine(AppContext.BaseDirectory, "Resources", "JsonSchemas", $"{schemaName}.json");
            using StreamReader file = File.OpenText(schemaPath);
            using JsonTextReader reader = new(file);
            JSchema schema = JSchema.Load(reader, new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(schemaPath)
            });
            AttachmentHelper.AddAttachmentAsJson("json schema", schema);
            Assert.That(response.GetBodyAsJson().IsValid(schema), "Json schema should match to expected");
        }


        [When("I extract the '(.*)' from the '(.*response.*)' with saving it as '(.*)'")]
        public void ExtractAndSave(string path, RestResponse response, string contextKey)
        {
            scenarioContext.Add(contextKey, response.ExtractPath(path));
        }

        [Then(@"the '(.*)' array has size less than or equal to (\d+) in the '(.*response.*)'")]
        public static void FieldArrayInResponseHasSizeLessThanOrEqualTo(string fieldName, int maxSize, RestResponse response)
        {
            var array = response.GetBodyAsJson().SelectToken(fieldName).ToObject<IReadOnlyList<object>>();
            Assert.That(array, Has.Count.LessThanOrEqualTo(maxSize), $"'{fieldName}' array should have expected size");
        }

        [Then(@"the '(.*)' array is ordered ascending by '(.*)' in the '(.*response.*)'")]
        public static void FieldArrayInResponseIsSortedAscending(string path, string fieldName, RestResponse response)
        {
            var array = response.GetBodyAsJson().SelectToken(path).ToArray();
            var sorted = array.OrderBy(jtoken => jtoken.SelectToken(fieldName));
            CollectionAssert.AreEqual(sorted, array, $"'{path}' array should be ordered ascending by {fieldName}");
        }
    }
}
