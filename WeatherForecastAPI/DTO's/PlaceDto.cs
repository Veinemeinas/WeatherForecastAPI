using System.Text.Json.Serialization;

namespace WeatherForecastAPI.DTO_s
{
    public class PlaceDto
    {
        [JsonPropertyName("code")]
        public string? Code { get; set; }
    }
}
