using CoffeeMakerApi.ServiceContracts;
using CoffeeMakerApi.Services;
using System;
using Xunit;

namespace CoffeeMakerApi.Tests
{
    public class BrewCoffeeServiceTests
    {
        private readonly IBrewCoffeeService _brewCoffeeService;

        public BrewCoffeeServiceTests()
        {
            _brewCoffeeService = new BrewCoffeeService();
        }

        [Fact]
        public void TestBrewCoffee()
        {
            var result = _brewCoffeeService.BrewCoffee();
            Assert.Equal("Your piping hot coffee is ready", result.Message);
        }

        [Fact]
        public void TestAreYouATeaPotTrue()
        {
            var result = _brewCoffeeService.AreYouATeaPot(DateTime.Now.Day, DateTime.Now.Month);
            Assert.True(result);
        }

        [Fact]
        public void TestAreYouATeaPotFalse()
        {
            var result = _brewCoffeeService.AreYouATeaPot(29, 2);
            Assert.False(result);
        }
    }
}
