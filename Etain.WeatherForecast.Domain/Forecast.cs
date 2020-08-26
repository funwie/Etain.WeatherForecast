using System;
using System.Text.Json.Serialization;

namespace Etain.WeatherForecast.Domain
{
    public class Forecast
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("applicable_date")]
        [JsonConverter(typeof(DateOnlyConverter))]
        public DateTime ApplicableDate { get; set; }

        [JsonPropertyName("weather_state_name")]
        public string StateName { get; set; }

        [JsonPropertyName("weather_state_abbr")]
        public string StateAbbr { get; set; }
        public string StateImageUrl { get; set; }

        [JsonPropertyName("the_temp")]
        public double TemperatureC { get; set; }
        public double TemperatureF { get; set; }
    }
}
