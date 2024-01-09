using DemoDualAPI.Models.DTOs;
using System.Text.Json;

namespace DemoDualAPI.Services
{

    public interface IWeatherService
    {
        Task<Weather> GetWeatherForCityAsync(string city);
    }
    public class WeatherService
    {
        private HttpClient _client;

        public WeatherService() : this(new HttpClient()) { }

        public WeatherService(HttpClient client)
        {
            _client = client;
        }

        public async Task<Weather> GetWeatherForCityAsync(string city)
        {
            var result = await _client.GetAsync($"https://goweather.herokuapp.com/weather/{city}");

            result.EnsureSuccessStatusCode();

            Weather weather = JsonSerializer.Deserialize<Weather>(await result.Content.ReadAsStringAsync());
        }
    }
}
