using Aquality.Selenium.Template.Configurations;
using Newtonsoft.Json;
using RestSharp;
using System.Linq;

namespace Aquality.Selenium.Template.Utilities
{
    public class RequestHandler
    {
        private readonly RestClient restClient = new RestClient(Configuration.ApiUrl);

        public RestResponse Execute(RestRequest request)
        {
            AddRequestHeadersToReport(request);
            AddRequestContentToReport(request);
            var response = restClient.Execute(request);
            AddResponseHeadersToReport(response);
            AddResponseInfoToReport(response);
            AddResponseContentToReport(response);
            return response;
        }

        private static void AddRequestHeadersToReport(RestRequest request)
        {
            var listOfHeaders = request.Parameters.Where(p => p.Type == ParameterType.HttpHeader).ToList();
            if (!listOfHeaders.Any())
            {
                return;
            }

            var formattedHeaders = listOfHeaders;
            AttachmentHelper.AddAttachmentAsJson("Request headers", formattedHeaders, NullValueHandling.Ignore);
        }

        private static void AddResponseHeadersToReport(RestResponse response)
        {
            var formattedHeaders = response.Headers;
            AttachmentHelper.AddAttachmentAsJson("Response headers", formattedHeaders, NullValueHandling.Ignore);
        }

        private static void AddResponseInfoToReport(RestResponse response)
        {
            var info = new
            {
                response.StatusCode,
                StatusDesciption = response.StatusDescription,
                Encoding = response.ContentEncoding,
                response.ErrorMessage,
                response.IsSuccessful,
                response.ResponseUri,
                response.ContentType,
                response.ContentLength,
                response.ResponseStatus
            };

            AttachmentHelper.AddAttachmentAsJson("Response common info", info);
        }

        private static void AddRequestContentToReport(RestRequest request, bool addRequestBodyToReport = true)
        {
            if (!addRequestBodyToReport)
            {
                return;
            }

            var param = request.Parameters.FirstOrDefault(e => e.Type == ParameterType.RequestBody);
            if (param?.Value == null)
            {
                return;
            }

            var content = param.Value.ToString();
            var contentType = request.RequestFormat.ToString().ToLower();
            var fileExt = $".{contentType}";
            AttachmentHelper.AddAttachment($"Request body ({request.RequestFormat})", $"application/{contentType}", content, fileExt);
        }

        private static void AddResponseContentToReport(RestResponse response)
        {
            var contentType = "text/plain";
            var content = response.Content;
            if (string.IsNullOrEmpty(content))
            {
                AttachmentHelper.AddAttachment("Empty response content", contentType, content);
            }
            else if (string.IsNullOrEmpty(response.ContentType))
            {
                AttachmentHelper.AddAttachment("Failed to parse the response content", contentType, content);
            }
            contentType = response.ContentType.ToLower();
            var extension = "";
            if (contentType.Contains("html"))
            {
                contentType = "text/html";
                extension = ".html";
            }
            else if (contentType.Contains("json"))
            {
                contentType = "application/json";
                extension = ".json";
                content = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(content), Formatting.Indented);
            }
            else if (contentType.Contains("xml"))
            {
                contentType = "application/xml";
                extension = ".xml";
            }
            AttachmentHelper.AddAttachment("Formatted content", contentType, content, extension);
        }
    }
}
