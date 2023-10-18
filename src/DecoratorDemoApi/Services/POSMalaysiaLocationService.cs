using System.Text.Json;
using DecoratorDemoApi.Models;

namespace DecoratorDemoApi.Services
{
    internal class POSMalaysiaLocationService : ILocationService
    {
        private readonly IHttpClientFactory _factory;
        private readonly Dictionary<string, List<Location>> _locations = new Dictionary<string, List<Location>>();
        public POSMalaysiaLocationService(IHttpClientFactory factory)
        {
            _factory = factory;
        }
        public async Task<List<Location>> GetLocationInfoByPostcode(string postcode)
        {
            var locations = new List<Location>();

            if (_locations.ContainsKey(postcode))
            {
                return _locations.GetValueOrDefault(postcode);
            }
            else
            {
                var client = _factory.CreateClient();
                var msg = new HttpRequestMessage(HttpMethod.Get, $"https://api.pos.com.my/PostcodeWebApi/api/Postcode?Postcode={postcode}");

                var result = await client.SendAsync(msg);

                if (result.IsSuccessStatusCode)
                {
                    var response = await result.Content.ReadAsStringAsync();

                    locations = JsonSerializer.Deserialize<List<Location>>(response);
                    _locations.Add(postcode, locations);
                }
            }

            return locations;
        }
    }
}
