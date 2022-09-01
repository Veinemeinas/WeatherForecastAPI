using Microsoft.AspNetCore.Mvc;
using WeatherForecastAPI.Services;

namespace WeatherForecastAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForecastController : ControllerBase
    {
        private readonly ForecastService _forecastService;

        public ForecastController(ForecastService forecastService)
        {
            _forecastService = forecastService;
        }

        [HttpGet]
        [Route("GetForecast/{place}")]
        public async Task<IActionResult> GetForecast(string place)
        {
            var forecast = await _forecastService.GetForecast(place);
            if (forecast == null)
            {
                return NotFound();
            }
            return Ok(forecast);
        }
    }
}
