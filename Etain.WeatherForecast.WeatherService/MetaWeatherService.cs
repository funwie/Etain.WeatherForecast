using Etain.WeatherForecast.Domain;
using Etain.WeatherForecast.Infrastructure.Interfaces;
using System;
using System.Linq;
using System.Text.Json;

namespace Etain.WeatherForecast.WeatherService
{

    public class MetaWeatherService : IWeatherService
    {
        public Weather GetWeatherForecastsForLocation(string locationWoeid)
        {
            if (string.IsNullOrWhiteSpace(locationWoeid))
            {
                locationWoeid = "44544"; // belfast
            }
            var metaWeatherAPIurl = $"https://www.metaweather.com/api/location/{locationWoeid}";
            var forecastTask = WebAPIClient.GetResourceAsync(metaWeatherAPIurl);

            var jsonData = forecastTask.Result;

            var consolidatedWeather = JsonSerializer.Deserialize<Weather>(jsonData);
            ProcessWeatherForecastForDisplay(consolidatedWeather);
            return consolidatedWeather;
        }

        private void ProcessWeatherForecastForDisplay(Weather weather)
        {
            var weatherImagesUrl = $"https://localhost:44362/images/weather"; // use app settings
            weather.WeatherForecast = weather.WeatherForecast.Select(x => ModifyForecastDetailsForDisplay(x, weatherImagesUrl));
        }

        private Forecast ModifyForecastDetailsForDisplay(Forecast forecast, string imgRoot)
        {
            forecast.TemperatureC = GetTemperatureDipslayValue(forecast.TemperatureC);
            var temf = 32 + (forecast.TemperatureC / 0.5556);
            forecast.TemperatureF = GetTemperatureDipslayValue(temf);

            forecast.StateImageUrl = $"{imgRoot}/{forecast.StateAbbr}.svg";

            return forecast;
        }

        private double GetTemperatureDipslayValue(double temp)
        {
            return Math.Truncate(temp * 100) / 100;
        }
    }
}
