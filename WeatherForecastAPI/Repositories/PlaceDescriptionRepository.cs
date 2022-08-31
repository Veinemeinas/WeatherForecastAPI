using Microsoft.EntityFrameworkCore;
using WeatherForecastAPI.Context;
using WeatherForecastAPI.Interfaces;
using WeatherForecastAPI.Models;

namespace WeatherForecastAPI.Repositories
{
    public class PlaceDescriptionRepository : IPlaceDescriptionRepository
    {
        private readonly WeatherForecastAPIContext _context;

        public PlaceDescriptionRepository(WeatherForecastAPIContext context)
        {
            _context = context;
        }

        public async Task<PlaceDescription> GetPlaceDescriptionAsync(int id)
        {
            return await _context.PlaceDescription.FirstOrDefaultAsync(pd => pd.Id == id);
        }

        public async Task<int> AddPlaceDescriptionAsync(PlaceDescription placeDescription)
        {
            await _context.PlaceDescription.AddAsync(placeDescription);
            return await _context.SaveChangesAsync();
        }
    }
}
