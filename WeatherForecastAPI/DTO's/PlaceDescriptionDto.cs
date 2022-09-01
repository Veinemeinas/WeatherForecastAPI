using System.Text.Json.Serialization;

namespace WeatherForecastAPI.DTO_s
{
    public class PlaceDescriptionDto
    {
        [JsonPropertyName("code")]
        public string? Code { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("administrativeDivision")]
        public string? AdministrativeDivision { get; set; }

        [JsonPropertyName("country")]
        public string? Country { get; set; }

        [JsonPropertyName("countryCode")]
        public string? CountryCode { get; set; }

        [JsonPropertyName("coordinates")]
        public CoordinatesDto? Coordinates { get; set; }
    }
}
