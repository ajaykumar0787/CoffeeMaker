using CoffeeMakerApi.Extensions;
using CoffeeMakerApi.ServiceContracts;
using CoffeeMakerApi.ViewModels;
using System;
using System.Threading.Tasks;

namespace CoffeeMakerApi.Services
{
    public class BrewCoffeeService : IBrewCoffeeService
    {
        private readonly IWeatherService _weatherService;

        public BrewCoffeeService(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        public async Task<BrewCoffeeViewModel> BrewCoffee()
        {
            //Data layer if any could be called here and if data layer is involved, we would have another class for data models and we could Auto Map it using the Automapper to view models

            var brewCoffeeViewModel = new BrewCoffeeViewModel();

            var currentTemp = await _weatherService.GetCurrentTemperatureInCelsius();

            brewCoffeeViewModel.Message = currentTemp.HasValue && currentTemp.Value > 30 ? "Your refreshing iced coffee is ready" : "Your piping hot coffee is ready";
            brewCoffeeViewModel.Prepared = DateTimeOffset.Now.Truncate(TimeSpan.FromSeconds(1));

            return brewCoffeeViewModel;
        }

        public bool AreYouATeaPot(int teapotDay, int teapotMonth)
        {
            return DateTime.Now.Month == teapotMonth && DateTime.Now.Day == teapotDay;
        }
    }
}
