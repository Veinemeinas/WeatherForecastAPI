using WeatherForecastAPI.Models;

namespace WeatherForecastAPI.Interfaces
{
    public interface IPlaceRepository
    {
        public Task<List<Place>> GetPlacesAsync();
        public Task<Place> GetPlaceAsync(int id);
        public Task<List<Place>> GetPlacesThatContainsAsync(string search);
        public Task<List<Place>> GetPlacesRangeAsync(int startAt, int capacity);
        public Task<int> AddPlaceAsync(Place place);
        public Task<int> UpdatePlaceAsync(Place place);
        public Task<int> RemovePlaceAsync(Place place);
    }
}
