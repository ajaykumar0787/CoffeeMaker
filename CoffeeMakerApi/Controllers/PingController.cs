using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeMakerApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PingController : BaseController
    {
        public PingController(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        { }

        /// <summary>
        /// Just to check if the service is alive
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok($"I am alive and I have been called from: {GetIpAddress()}");
        }
    }
}
