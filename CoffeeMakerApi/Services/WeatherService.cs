using CoffeeMakerApi.Models;
using CoffeeMakerApi.ServiceContracts;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CoffeeMakerApi.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly string _apiUrl;

        public WeatherService(string apiUrl)
        {
            _apiUrl = apiUrl;
        }

        public async Task<double?> GetCurrentTemperatureInCelsius()
        {
            double? temperature = null;
            try
            {
                using (var client = new HttpClient())
                {
                    using var request = new HttpRequestMessage(HttpMethod.Get, _apiUrl);
                    using var response = await client.SendAsync(request).ConfigureAwait(true);

                    if(response.IsSuccessStatusCode)
                    {
                        if(response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            var content = await response.Content.ReadAsStringAsync();
                            var weatherModel = JsonConvert.DeserializeObject<WeatherModel>(content);

                            temperature = weatherModel.MainWeatherModel.Temperature;
                        }
                    }
                }

                return temperature;
            }
            catch(Exception ex)
            {
                //TODO: Logging & based on further requirement we could respond with different message
                Console.WriteLine(ex);
                return null;
            }
        }
    }
}
