using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using RestSharp;

namespace Aquality.Selenium.Template.Utilities
{
    public static class RestResponseExtensions
    {
        public static string ExtractPath(this RestResponse response, string path)
        {
            return GetBodyAsJson(response).SelectToken(path).Value<string>();
        }

        public static JToken GetBodyAsJson(this RestResponse response)
        {
            return JToken.Parse(response.Content);
        }

        public static T GetBodyAs<T>(this RestResponse response)
        {
            var contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            };
            return JsonConvert.DeserializeObject<T>(response.Content, new JsonSerializerSettings
            {
                ContractResolver = contractResolver,
                Formatting = Formatting.Indented
            });
        }
    }
}
