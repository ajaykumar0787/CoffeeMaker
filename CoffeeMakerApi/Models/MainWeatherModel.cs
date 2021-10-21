using Newtonsoft.Json;

namespace CoffeeMakerApi.Models
{
    public class MainWeatherModel
    {
        [JsonProperty("temp")]
        public double Temperature { get; set; }
        [JsonProperty("feels_like")]
        public double FeelsLike { get; set; }
        [JsonProperty("temp_min")]
        public double MinimumTemperature { get; set; }
        [JsonProperty("temp_max")]
        public double MaximumTemperature { get; set; }
    }
}
