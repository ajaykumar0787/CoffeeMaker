using System;

namespace CoffeeMakerApi.ViewModels
{
    public class BrewCoffeeViewModel
    {
        public string Message { get; set; }
        public DateTimeOffset Prepared { get; set; }
    }
}
