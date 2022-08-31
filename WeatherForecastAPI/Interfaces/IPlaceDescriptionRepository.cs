using WeatherForecastAPI.Models;

namespace WeatherForecastAPI.Interfaces
{
    public interface IPlaceDescriptionRepository
    {
        public Task<PlaceDescription> GetPlaceDescriptionAsync(int id);

        public Task<int> AddPlaceDescriptionAsync(PlaceDescription placeDescription);
    }
}
