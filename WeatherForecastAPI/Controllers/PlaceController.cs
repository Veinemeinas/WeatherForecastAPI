using Microsoft.AspNetCore.Mvc;
using WeatherForecastAPI.Interfaces;

namespace WeatherForecastAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaceController : ControllerBase
    {
        private readonly IPlaceRepository _placeRepository;

        public PlaceController(IPlaceRepository placeRepository)
        {
            _placeRepository = placeRepository;
        }

        [HttpGet]
        [Route("GetPlacesRange/{startAt}/{capacity}")]
        public async Task<IActionResult> GetPlacesRangeAsync(int startAt, int capacity)
        {
            var places = await _placeRepository.GetPlacesRangeAsync(startAt, capacity);
            if (places == null)
            {
                return NotFound();
            }
            return Ok(places);
        }

        [HttpGet]
        [Route("SearchPlaces/{search}")]
        public async Task<IActionResult> GetPlacesThatContainsAsync(string search)
        {
            var places = await _placeRepository.GetPlacesThatContainsAsync(search);
            if (places == null)
            {
                return NotFound();
            }
            return Ok(places);
        }

        [HttpGet]
        [Route("GetPlace/{id}")]
        public async Task<IActionResult> GetPlaceAsync(int id)
        {
            var place = await _placeRepository.GetPlaceAsync(id);
            if (place == null)
            {
                return NotFound();
            }
            return Ok(place);
        }
    }
}
