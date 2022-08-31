using Microsoft.EntityFrameworkCore;
using WeatherForecastAPI.Context;
using WeatherForecastAPI.Interfaces;
using WeatherForecastAPI.Models;

namespace WeatherForecastAPI.Repositories
{
    public class PlaceRepository : IPlaceRepository
    {
        private readonly WeatherForecastAPIContext _context;

        public PlaceRepository(WeatherForecastAPIContext context)
        {
            _context = context;
        }

        public async Task<List<Place>> GetPlacesAsync()
        {
            return await _context.Places.ToListAsync();
        }

        public async Task<int> AddPlaceAsync(Place place)
        {
            await _context.Places.AddAsync(place);
            return await _context.SaveChangesAsync();
        }
    }
}
