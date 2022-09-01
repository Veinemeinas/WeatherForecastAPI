using AutoMapper;

namespace WeatherForecastAPI.Profiles
{
    public class PlaceProfile : Profile
    {
        public PlaceProfile()
        {
            // CreateMap<PlaceDescriptionDto, Place>().ForMember(;


            //.ForMember(dest => dest.Coordinates, opt => opt.MapFrom(c => c.Coordinates));


            //  CreateMap<DomainClass, Child>();
            //   CreateMap<DomainClass, Parent>()
            //    .ForMember(d => d.Child, opt => opt.MapFrom(s => s));
        }
    }
}
