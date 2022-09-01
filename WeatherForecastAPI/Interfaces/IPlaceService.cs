using WeatherForecastAPI.DTO_s;

namespace WeatherForecastAPI.Interfaces
{
    public interface IPlaceService
    {
        public Task<IEnumerable<PlaceDto>> GetPlacesAsync(string url);
        public Task<PlaceDescriptionDto> GetPlaceAsync(string url);
    }
}
