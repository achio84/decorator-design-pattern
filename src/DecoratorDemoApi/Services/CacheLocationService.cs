using DecoratorDemoApi.Models;

namespace DecoratorDemoApi.Services
{
    internal class CacheLocationService : ILocationService
    {
        private readonly ILocationService _locationService;
        private readonly Dictionary<string, List<Location>> _locationDictionary = new Dictionary<string, List<Location>>();

        public CacheLocationService(ILocationService locationService)
        {
            _locationService = locationService;
        }

        public async Task<List<Location>> GetLocationInfoByPostcode(string postcode)
        {
            if (_locationDictionary.ContainsKey(postcode))
            {
                return _locationDictionary.GetValueOrDefault(postcode);
            }
            else
            {
                var locations = await _locationService.GetLocationInfoByPostcode(postcode);
                _locationDictionary.Add(postcode, locations);

                return locations;
            }
        }
    }
}
