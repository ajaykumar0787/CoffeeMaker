using CoffeeMakerApi.ViewModels;
using System.Threading.Tasks;

namespace CoffeeMakerApi.ServiceContracts
{
    public interface IBrewCoffeeService
    {
        Task<BrewCoffeeViewModel> BrewCoffee();
        bool AreYouATeaPot(int teapotDay, int teapotMonth);
    }
}
