using System.Text.Json.Serialization;

namespace WeatherForecastAPI.Models
{
    public class ForecastTimestamp
    {
        [JsonPropertyName("forecastTimeUtc")]
        public string ForecastTimeUtc { get; set; }

        [JsonPropertyName("airTemperature")]
        public double AirTemperature { get; set; }

        [JsonPropertyName("windSpeed")]
        public int WindSpeed { get; set; }

        [JsonPropertyName("windGust")]
        public int WindGust { get; set; }

        [JsonPropertyName("windDirection")]
        public int WindDirection { get; set; }

        [JsonPropertyName("cloudCover")]
        public int CloudCover { get; set; }

        [JsonPropertyName("seaLevelPressure")]
        public int SeaLevelPressure { get; set; }

        [JsonPropertyName("relativeHumidity")]
        public int RelativeHumidity { get; set; }

        [JsonPropertyName("totalPrecipitation")]
        public float TotalPrecipitation { get; set; }

        [JsonPropertyName("conditionCode")]
        public string ConditionCode { get; set; }
    }
}
