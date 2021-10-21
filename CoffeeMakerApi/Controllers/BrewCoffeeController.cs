using CoffeeMakerApi.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace CoffeeMakerApi.Controllers
{
    [Route("api/brew-coffee")]
    [ApiController]
    public class BrewCoffeeController : BaseController
    {
        private readonly IBrewCoffeeService _brewCoffeeService;
        private readonly int _teapotDay;
        private readonly int _teapotMonth;

        public BrewCoffeeController(IHttpContextAccessor httpContextAccessor, IConfiguration configuration, IBrewCoffeeService brewCoffeeService): base(httpContextAccessor)
        {
            _brewCoffeeService = brewCoffeeService;

            var configSection = configuration.GetSection("TeapotDate");
            _teapotDay = configSection.GetValue<int>("Day");
            _teapotMonth = configSection.GetValue<int>("Month");
        }

        /// <summary>
        /// Brews the coffee for you. If the date meets a certain criteria that makes it a teapot, you get 418, if it runs out of coffee it returns 503, else you get your coffee
        /// </summary>
        /// <returns>Message, Prepared Time</returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                if(_brewCoffeeService.AreYouATeaPot(_teapotDay, _teapotMonth))
                    return StatusCode(StatusCodes.Status418ImATeapot, string.Empty);

                var brewCoffeeViewModel = await _brewCoffeeService.BrewCoffee();

                return Ok(brewCoffeeViewModel);
            }
            catch(Exception ex)
            {
                //TODO: Log any errors to the DB or the log file or any log aggregator like New Relic/Splunk
                Console.WriteLine(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while brewing coffee. If the issue persists, please contact helpdesk");
            }
        }
    }
}
