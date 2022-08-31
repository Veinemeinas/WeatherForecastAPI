namespace WeatherForecastAPI.Models
{
    public class PlaceDescription
    {
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? AdministrativeDivision { get; set; }
        public string? Country { get; set; }
        public string? CountryCode { get; set; }
        public Coordinates? Coordinates { get; set; }
    }
}
