using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Etain.WeatherForecast.Domain
{
    public class Weather
    {
        [JsonPropertyName("consolidated_weather")]
        public IEnumerable<Forecast> WeatherForecast { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("woeid")]
        public int Woeid { get; set; }

        [JsonPropertyName("timezone")]
        public string Timezone { get; set; }
    }
}
