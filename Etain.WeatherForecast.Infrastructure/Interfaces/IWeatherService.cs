using System.Collections.Generic;
using Etain.WeatherForecast.Domain;

namespace Etain.WeatherForecast.Infrastructure.Interfaces
{
    public interface IWeatherService
    {
        Weather GetWeatherForecastsForLocation(string locationWoeid);
    }
}
