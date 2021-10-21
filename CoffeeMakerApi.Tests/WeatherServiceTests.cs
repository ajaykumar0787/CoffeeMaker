using CoffeeMakerApi.Services;
using Xunit;

namespace CoffeeMakerApi.Tests
{
    public class WeatherServiceTests
    {
        [Fact]
        public async void TestGetCurrentWeatherValidKey()
        {
            var weatherService = new WeatherService("https://api.openweathermap.org/data/2.5/weather?q=Sydney,au&APPID=0bb93941f5ec0141c203b992dd4620a9&units=metric");
            var result = await weatherService.GetCurrentTemperatureInCelsius();
            Assert.NotNull(result);
        }

        [Fact]
        public async void TestGetCurrentWeatherInValidKey()
        {
            var weatherService = new WeatherService("https://api.openweathermap.org/data/2.5/weather?q=Sydney,au&APPID=abcd&units=metric");
            var result = await weatherService.GetCurrentTemperatureInCelsius();
            Assert.Null(result);
        }
    }
}
