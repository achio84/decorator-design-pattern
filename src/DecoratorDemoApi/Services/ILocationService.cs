using DecoratorDemoApi.Models;

namespace DecoratorDemoApi.Services
{
    public interface ILocationService
    {
        Task<List<Location>> GetLocationInfoByPostcode(string postcode);
    }
}
