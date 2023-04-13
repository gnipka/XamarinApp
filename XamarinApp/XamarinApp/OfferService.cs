using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using XamarinApp.Models;

namespace XamarinApp
{
    public static class OfferService
    {
        const string Url = "https://10.0.0.2:44356/Offer/";

        private static HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }

        public static async Task<IEnumerable<Offer>> Get()
        {
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            HttpClient client = GetClient();
            string result = await client.GetStringAsync(Url);
            return System.Text.Json.JsonSerializer.Deserialize<IEnumerable<Offer>>(result, options);
        }
    }
}
