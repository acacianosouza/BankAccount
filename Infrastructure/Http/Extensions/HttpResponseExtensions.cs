using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Threading.Tasks;

namespace Infrastructure.Http.Extensions
{
    public static class HttpResponseExtensions
    {
        public static async Task WriteJson<TResponse>(this HttpResponse httpResponse, TResponse response, int httpStatusCode)
        {
            var jsonSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            var json = JsonConvert.SerializeObject(response, jsonSettings);
            httpResponse.StatusCode = httpStatusCode;
            httpResponse.Headers.Add("Content-Type", "application/json");
            await httpResponse.WriteAsync(json);
        }
    }
}