using Aquality.Selenium.Template.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using NUnit.Framework;
using RestSharp;
using System;
using System.IO;
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

        [Then(@"the '(.*response.*)' matches json schema '(.*)'")]
        public void AssertResponseIsValidSchema(RestResponse response, string schemaName)
        {
            var schemaPath = GetSchemaPath(schemaName);
            using (StreamReader file = File.OpenText(schemaPath))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JSchemaUrlResolver resolver = new JSchemaUrlResolver();

                JSchema schema = JSchema.Load(reader, new JSchemaReaderSettings
                {
                    Resolver = resolver,
                    BaseUri = new Uri(schemaPath)
                });
                var availablity = JToken.Parse(response.Content);
                AttachmentHelper.AddAttachmentAsJson("json schema", schema);
                Assert.That(availablity.IsValid(schema), Is.True, "Json schema should match to expected");
            }
        }

        private static string GetSchemaPath(string fileName)
        {
            return Path.Combine(AppContext.BaseDirectory, "Resources", "JsonSchemas", $"{fileName}.json");
        }
    }
}
