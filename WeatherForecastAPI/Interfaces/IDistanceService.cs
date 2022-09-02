using WeatherForecastAPI.DTO_s;
using WeatherForecastAPI.Models;

namespace WeatherForecastAPI.Interfaces
{
    public interface IDistanceService
    {
        public List<DistanceDto> GetDistance(List<Place> places, CoordinatesDto coordinates);
    }
}
