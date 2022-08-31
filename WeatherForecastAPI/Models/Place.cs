namespace WeatherForecastAPI.Models
{
    public class Place
    {
        public int Id { get; set; }
        public string? Code { get; set; }
        public PlaceDescription? PlaceDescription { get; set; }
    }
}
