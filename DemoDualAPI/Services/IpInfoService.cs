namespace DemoDualAPI.Services
{
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
        public async Task<string> GetCityAsync()
        {

        }
    }
}
