using Microsoft.EntityFrameworkCore;
using WeatherForecastAPI.Context;
using WeatherForecastAPI.DTO_s;
using WeatherForecastAPI.Interfaces;
using WeatherForecastAPI.Models;

namespace WeatherForecastAPI.Repositories
{
    public class PlaceRepository : IPlaceRepository
    {
        private readonly WeatherForecastAPIContext _context;
        private readonly IDistanceService _distanceService;

        public PlaceRepository(WeatherForecastAPIContext context, IDistanceService distanceService)
        {
            _context = context;
            _distanceService = distanceService;
        }

        public async Task<List<Place>> GetPlacesAsync()
        {
            return await _context.Places.ToListAsync();
        }

        public async Task<List<DistanceDto>> GetNearestPlacesAsync(CoordinatesDto coordinatesDto)
        {
            var places = await _context.Places.Include(p => p.Coordinates).ToListAsync();
            return _distanceService.GetDistance(places, coordinatesDto);
        }

        public async Task<Place> GetPlaceAsync(int id)
        {
            return await _context.Places.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Place>> GetPlacesThatContainsAsync(string search)
        {
            return await _context.Places.Where(p => p.Code.Contains(search) || p.Name.Contains(search)).ToListAsync();
        }

        public async Task<List<Place>> GetPlacesRangeAsync(int startAt, int capacity)
        {
            return await _context.Places.Skip(startAt).Take(capacity).ToListAsync();
        }

        public async Task<int> AddPlaceAsync(Place place)
        {
            await _context.Places.AddAsync(place);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdatePlaceAsync(Place place)
        {
            _context.Places.Update(place);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> RemovePlaceAsync(Place place)
        {
            _context.Places.Remove(place);
            return await _context.SaveChangesAsync();
        }
    }
}
