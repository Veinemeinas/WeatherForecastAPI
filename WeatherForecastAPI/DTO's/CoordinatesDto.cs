using System.Text.Json.Serialization;

namespace WeatherForecastAPI.DTO_s
{
    public class CoordinatesDto
    {
        [JsonPropertyName("latitude")]
        public float Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public float Longitude { get; set; }
    }
}
