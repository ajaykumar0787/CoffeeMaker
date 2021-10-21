using CoffeeMakerApi.Extensions;
using CoffeeMakerApi.ServiceContracts;
using CoffeeMakerApi.ViewModels;
using System;

namespace CoffeeMakerApi.Services
{
    public class BrewCoffeeService : IBrewCoffeeService
    {
        public BrewCoffeeViewModel BrewCoffee()
        {
            //Data layer if any could be called here and if data layer is involved, we would have another class for data models and we could Auto Map it using the Automapper to view models
            return new BrewCoffeeViewModel { Message = "Your piping hot coffee is ready", Prepared = DateTimeOffset.Now.Truncate(TimeSpan.FromSeconds(1)) };
        }

        public bool AreYouATeaPot(int teapotDay, int teapotMonth)
        {
            return DateTime.Now.Month == teapotMonth && DateTime.Now.Day == teapotDay;
        }
    }
}
