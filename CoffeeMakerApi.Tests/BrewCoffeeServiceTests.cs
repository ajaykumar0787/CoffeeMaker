using CoffeeMakerApi.ServiceContracts;
using CoffeeMakerApi.Services;
using Moq;
using System;
using Xunit;

namespace CoffeeMakerApi.Tests
{
    public class BrewCoffeeServiceTests
    {
        private Mock<IWeatherService> mockWeatherService = new Mock<IWeatherService>();

        [Fact]
        public async void TestBrewCoffeeHot()
        {
            mockWeatherService.Setup(p => p.GetCurrentTemperatureInCelsius()).ReturnsAsync(0.0);
            var brewCoffeeService = new BrewCoffeeService(mockWeatherService.Object);
            var result = await brewCoffeeService.BrewCoffee();
            Assert.Equal("Your piping hot coffee is ready", result.Message);
        }

        [Fact]
        public async void TestBrewCoffeeCold()
        {
            mockWeatherService.Setup(p => p.GetCurrentTemperatureInCelsius()).ReturnsAsync(31.0);
            var brewCoffeeService = new BrewCoffeeService(mockWeatherService.Object);
            var result = await brewCoffeeService.BrewCoffee();
            Assert.Equal("Your refreshing iced coffee is ready", result.Message);
        }

        [Fact]
        public void TestAreYouATeaPotTrue()
        {
            mockWeatherService.Setup(p => p.GetCurrentTemperatureInCelsius()).ReturnsAsync(0.0);
            var brewCoffeeService = new BrewCoffeeService(mockWeatherService.Object);
            var result = brewCoffeeService.AreYouATeaPot(DateTime.Now.Day, DateTime.Now.Month);
            Assert.True(result);
        }

        [Fact]
        public void TestAreYouATeaPotFalse()
        {
            mockWeatherService.Setup(p => p.GetCurrentTemperatureInCelsius()).ReturnsAsync(0.0);
            var brewCoffeeService = new BrewCoffeeService(mockWeatherService.Object);
            var result = brewCoffeeService.AreYouATeaPot(29, 2);
            Assert.False(result);
        }
    }
}
