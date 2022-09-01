using System.Text.Json.Serialization;

namespace WeatherForecastAPI.Models
{
    public class Forecast
    {
        [JsonPropertyName("place")]
        public Place Place { get; set; }

        [JsonPropertyName("forecastType")]
        public string ForecastType { get; set; }

        [JsonPropertyName("forecastCreationTimeUtc")]
        public string ForecastCreationTimeUtc { get; set; }

        [JsonPropertyName("forecastTimestamps")]
        public List<ForecastTimestamp> ForecastTimestamps { get; set; }
    }
}
