using Microsoft.EntityFrameworkCore;
using WeatherForecastAPI.Models;

namespace WeatherForecastAPI.Context
{
    public class WeatherForecastAPIContext : DbContext
    {
        public WeatherForecastAPIContext(DbContextOptions options) : base(options) { }

        public DbSet<Place> Places { get; set; }
        public DbSet<PlaceDescription> PlaceDescription { get; set; }
        public DbSet<Coordinates> Coordinates { get; set; }
    }
}
