using DecoratorDemoApi.Models;
using System.Text.Json;

namespace DecoratorDemoApi.Services
{
    internal class POSMalaysiaLocationService : ILocationService
    {
        private readonly IHttpClientFactory _factory;

        public POSMalaysiaLocationService(IHttpClientFactory factory)
        {
            _factory = factory;
        }
        public async Task<List<Location>> GetLocationInfoByPostcode(string postcode)
        {
            var locations = new List<Location>();

            var client = _factory.CreateClient();
            var msg = new HttpRequestMessage(HttpMethod.Get, $"https://api.pos.com.my/PostcodeWebApi/api/Postcode?Postcode={postcode}");

            var result = await client.SendAsync(msg);

            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadAsStringAsync();

                locations = JsonSerializer.Deserialize<List<Location>>(response);
            }

            return locations;
        }
    }
}
