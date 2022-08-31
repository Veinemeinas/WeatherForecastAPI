using AutoMapper;
using System.Text;
using WeatherForecastAPI.Interfaces;
using WeatherForecastAPI.Models;
using WeatherForecastAPI.Repositories;

namespace WeatherForecastAPI.Services
{
    public class BackgroundWorkerService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IMapper _mapper;

        public BackgroundWorkerService(IServiceProvider serviceProvider, IMapper mapper)
        {
            _serviceProvider = serviceProvider;
            _mapper = mapper;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using (IServiceScope scope = _serviceProvider.CreateScope())
            {
                IPlaceService placeService = scope.ServiceProvider.GetService<IPlaceService>();
                IPlaceRepository placeRepository = scope.ServiceProvider.GetService<IPlaceRepository>();
                PlaceDescriptionRepository placeDescriptionRepository = scope.ServiceProvider.GetService<PlaceDescriptionRepository>();

                do
                {
                    int hoursSpan = 15 - DateTime.Now.Hour;

                    if (hoursSpan == 0)
                    {
                        var placesDto = await placeService.GetPlacesAsync("https://api.meteo.lt/v1/places");
                        var places = await placeRepository.GetPlacesAsync();

                        foreach (var placeDto in placesDto)
                        {
                            var result = places.FirstOrDefault(p => p.Code == placeDto.Code);

                            if (result == null)
                            {
                                var place = _mapper.Map<Place>(placeDto);
                                await placeRepository.AddPlaceAsync(place);
                                StringBuilder stringBuilder = new StringBuilder("https://api.meteo.lt/v1/places/");
                                stringBuilder.AppendLine(place.Code);

                                var placeDescriptionDto = await placeService.GetPlaceAsync(stringBuilder.ToString());

                                PlaceDescription placeDescription = new PlaceDescription()
                                {
                                    Code = placeDescriptionDto.Code,
                                    Name = placeDescriptionDto.Name,
                                    AdministrativeDivision = placeDescriptionDto.AdministrativeDivision,
                                    Country = placeDescriptionDto.Country,
                                    CountryCode = placeDescriptionDto.CountryCode,
                                    Coordinates = new Coordinates()
                                    {
                                        Latitude = placeDescriptionDto.Coordinates.Latitude,
                                        Longitude = placeDescriptionDto.Coordinates.Longitude
                                    }
                                };

                                //Need to make other logic

                                await placeDescriptionRepository.AddPlaceDescriptionAsync(placeDescription);
                                Task.Delay(100);
                                Console.WriteLine(placeDescription.Name);
                            }
                        }

                        hoursSpan = 24;
                    }

                    await Task.Delay(TimeSpan.FromHours(hoursSpan), stoppingToken);
                } while (!stoppingToken.IsCancellationRequested);
            }
        }
    }
}
