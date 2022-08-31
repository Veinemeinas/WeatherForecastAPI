using WeatherForecastAPI.Models;

namespace WeatherForecastAPI.Interfaces
{
    public interface IPlaceRepository
    {
        public Task<List<Place>> GetPlacesAsync();

        public Task<int> AddPlaceAsync(Place place);
    }
}
