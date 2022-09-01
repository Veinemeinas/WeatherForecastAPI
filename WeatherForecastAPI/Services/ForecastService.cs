using System.Text.Json;
using WeatherForecastAPI.Models;

namespace WeatherForecastAPI.Services
{
    public class ForecastService
    {
        private readonly IConfiguration _configuration;

        public ForecastService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Forecast> GetForecast(string code)
        {
            string forecastUrl = _configuration["ApiEndpoints:ForecastUrl"].Replace("#place", code);

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetStreamAsync(forecastUrl);
                return await JsonSerializer.DeserializeAsync<Forecast>(response);
            }
        }
    }
}
