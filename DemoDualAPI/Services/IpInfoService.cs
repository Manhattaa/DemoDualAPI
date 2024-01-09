using DemoDualAPI.Models.DTOs;
using System.Text.Json;

namespace DemoDualAPI.Services
{
    public interface IIpInfoService
    {
        Task<string> GetCityAsync(string ip);
    }
    public class IpInfoService
    {
        private HttpClient _client;
        public IpInfoService(HttpClient client)
        {
            _client = client;
        }

        public IpInfoService() : this(new HttpClient())
        {

        }
        public async Task<string> GetCityAsync(string ip)
        {
            var result = await _client.GetAsync($"http://ip-api.com/json/{ip}");

            result.EnsureSuccessStatusCode();

            IpInfo ipInfo = JsonSerializer.Deserialize<IpInfo>(await result.Content.ReadAsStringAsync());

            return ipInfo.City;
        }
    }
}
