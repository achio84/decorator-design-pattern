using DecoratorDemoApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace DecoratorDemoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]string postcode)
        {
            var locations = await _locationService.GetLocationInfoByPostcode(postcode);

            return Ok(locations);
        }
    }
}