using Newtonsoft.Json;

namespace CoffeeMakerApi.Models
{
    public class WeatherModel
    {
        [JsonProperty("main")]
        public MainWeatherModel MainWeatherModel { get; set; }
    }
}
