using CoffeeMakerApi.ViewModels;

namespace CoffeeMakerApi.ServiceContracts
{
    public interface IBrewCoffeeService
    {
        BrewCoffeeViewModel BrewCoffee();
        bool AreYouATeaPot(int teapotDay, int teapotMonth);
    }
}
