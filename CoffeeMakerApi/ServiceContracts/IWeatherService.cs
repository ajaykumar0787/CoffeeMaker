using System.Threading.Tasks;

namespace CoffeeMakerApi.ServiceContracts
{
    public interface IWeatherService
    {
        Task<double?> GetCurrentTemperatureInCelsius();
    }
}
