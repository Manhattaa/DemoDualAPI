using System.Text.Json.Serialization;

namespace DemoDualAPI.Models.DTOs
{
    public class Weather
    {
        // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
        public class Forecast
        {
            [JsonPropertyName("day")]
            public string Day { get; set; }

            [JsonPropertyName("temperature")]
            public string Temperature { get; set; }

            [JsonPropertyName("wind")]
            public string Wind { get; set; }
        }

        public class Weather
        {
            [JsonPropertyName("temperature")]
            public string Temperature { get; set; }

            [JsonPropertyName("wind")]
            public string Wind { get; set; }

            [JsonPropertyName("description")]
            public string Description { get; set; }

            [JsonPropertyName("forecast")]
            public List<Forecast> Forecast { get; set; }
        }
    }
}
