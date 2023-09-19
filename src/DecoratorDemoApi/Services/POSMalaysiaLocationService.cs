using System.Text.Json;
using DecoratorDemoApi.Models;

namespace DecoratorDemoApi.Services
{
    internal class POSMalaysiaLocationService : ILocationService
    {
        public async Task<List<Location>> GetLocationInfoByPostcode(string postcode)
        {
            var locations = new List<Location>();
            using var client = new HttpClient();
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
