using Etain.WeatherForecast.Domain;
using Etain.WeatherForecast.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Etain.WeatherForecast.Web.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherService _weatherService;

        public WeatherForecastController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpGet]
        public Weather Get(string locationWoeid)
        {
            return _weatherService.GetWeatherForecastsForLocation(locationWoeid);
        }
    }
}
