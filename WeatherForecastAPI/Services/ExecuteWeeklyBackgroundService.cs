using AutoMapper;
using System.Text;
using WeatherForecastAPI.Interfaces;
using WeatherForecastAPI.Models;

namespace WeatherForecastAPI.Services
{
    public class ExecuteWeeklyBackgroundService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public ExecuteWeeklyBackgroundService(IServiceProvider serviceProvider, IConfiguration configuration, IMapper mapper)
        {
            _serviceProvider = serviceProvider;
            _configuration = configuration;
            _mapper = mapper;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            string placeUrl = _configuration["ApiEndpoints:PlacesUrl"];

            using (IServiceScope scope = _serviceProvider.CreateScope())
            {
                IPlaceService placeService = scope.ServiceProvider.GetService<IPlaceService>();
                IPlaceRepository placeRepository = scope.ServiceProvider.GetService<IPlaceRepository>();

                while (!stoppingToken.IsCancellationRequested)
                {
                    var now = DateTime.Now;
                    var weekDay = 7 - ((int)now.DayOfWeek);
                    var hours = 23 - now.Hour;
                    var minutes = 59 - now.Minute;
                    var seconds = 59 - now.Second;
                    var secondsTillCheckig = weekDay * 86400 + hours * 3600 + minutes * 60 + seconds;

                    await Task.Delay(TimeSpan.FromSeconds(secondsTillCheckig), stoppingToken);

                    var placesDto = await placeService.GetPlacesAsync(placeUrl);
                    var places = await placeRepository.GetPlacesAsync();

                    foreach (var placeDto in placesDto)
                    {
                        var result = places.FirstOrDefault(p => p.Code == placeDto.Code);

                        if (result == null)
                        {
                            StringBuilder stringBuilder = new StringBuilder(placeUrl);
                            stringBuilder.Append(placeDto.Code);

                            var placeDescriptionDto = await placeService.GetPlaceAsync(stringBuilder.ToString());

                            Place place = new Place()
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

                            await placeRepository.AddPlaceAsync(place);
                        }
                    }
                    await Task.Delay(TimeSpan.FromMinutes(2));
                }
            }
        }
    }
}
