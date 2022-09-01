using System.Text.Json;
using WeatherForecastAPI.DTO_s;
using WeatherForecastAPI.Interfaces;

namespace WeatherForecastAPI.Services
{
    public class PlaceService : IPlaceService
    {
        private readonly IConfiguration _configuration;

        public PlaceService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<PlaceDto>> GetPlacesAsync(string url)
        {
            string placeUrl = _configuration["ApiEndpoints:Place"];

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetStreamAsync(url);
                return await JsonSerializer.DeserializeAsync<IEnumerable<PlaceDto>>(response);
            }
        }

        public async Task<PlaceDescriptionDto> GetPlaceAsync(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetStreamAsync(url);
                return await JsonSerializer.DeserializeAsync<PlaceDescriptionDto>(response);
            }
        }
    }
}
