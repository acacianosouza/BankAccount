using System.Net.Http;
using System.Threading.Tasks;

namespace Infrastructure.Http.Extensions
{
    public static class HttpMessageExtensions
    {
        public static async Task<T> ResponseAsObject<T>(this HttpContent content)
        {
            var responseText = await content.ReadAsStringAsync();
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(responseText);
        }
    }
}
