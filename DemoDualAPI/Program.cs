using DemoDualAPI.Models.DTOs;
using DemoDualAPI.Models.ViewModels;
using DemoDualAPI.Services;
using System.Security.Principal;

namespace DemoDualAPI
{
    public class Program
    {
        public static async void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddScoped<IIpInfoService, IpInfoService>();
            builder.Services.AddScoped<IWeatherService>, WeatherService > ();


            var app = builder.Build();

            app.MapGet("/", () => "Hello World!");

            app.MapGet("/{ip}", async (string ip, IIpInfoService ipInfoService, IWeatherService weatherService) => 
                {
                string city = await ipInfoService.GetCityAsync(ip);
                    Weather weather = await weatherService.GetWeatherForCityAsync(city);

                    WeatherViewModel result = new WeatherViewModel();
                    {
                    Temperature = weather.Temperature,
                    Wind = weather.Wind,
                    Description = weather.Description,
                    City = city,
                    };
                    return Results.Json(result);
            });

            app.Run();
        }
    }
}
