using AutoMapper;
using WeatherForecastAPI.DTO_s;
using WeatherForecastAPI.Models;

namespace WeatherForecastAPI.Profiles
{
    public class PlaceProfile : Profile
    {
        public PlaceProfile()
        {
            CreateMap<PlaceDto, Place>();
        }
    }
}
