using Microsoft.EntityFrameworkCore;
using WeatherForecastAPI.Context;
using WeatherForecastAPI.Interfaces;
using WeatherForecastAPI.Repositories;
using WeatherForecastAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ConfigurationManager configuration = builder.Configuration;

builder.Services.AddDbContext<WeatherForecastAPIContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddHostedService<ExecuteWeeklyBackgroundService>();
builder.Services.AddScoped<IPlaceRepository, PlaceRepository>();
builder.Services.AddScoped<IPlaceService, PlaceService>();
builder.Services.AddScoped<ForecastService>();
builder.Services.AddScoped<IDistanceService, DistanceService>();
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
