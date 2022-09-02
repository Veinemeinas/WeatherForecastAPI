using GeoCoordinatePortable;
using WeatherForecastAPI.DTO_s;
using WeatherForecastAPI.Interfaces;
using WeatherForecastAPI.Models;

namespace WeatherForecastAPI.Services
{
    public class DistanceService : IDistanceService
    {
        public List<DistanceDto> GetDistance(List<Place> places, CoordinatesDto coordinates)
        {
            if (coordinates.Latitude < -90 && coordinates.Latitude > 90 && coordinates.Longitude < -180 && coordinates.Longitude > 180)
            {
                return null;
            }

            GeoCoordinate location1 = new GeoCoordinate(coordinates.Latitude, coordinates.Longitude);

            List<DistanceDto> distances = new List<DistanceDto>();

            foreach (var place in places)
            {
                GeoCoordinate location2 = new GeoCoordinate(place.Coordinates.Latitude, place.Coordinates.Longitude);
                double distance = location1.GetDistanceTo(location2) / 1000;
                DistanceDto distanceDto = new DistanceDto() { PlaceId = place.Id, Distance = distance };
                distances.Add(distanceDto);
            }

            var sortedByDistance = distances.OrderBy(d => d.Distance).Take(20).ToList();

            return sortedByDistance;
        }
    }
}
