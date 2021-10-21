using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeMakerApi.Controllers
{
    /// <summary>
    /// Api Base class. This implements all the methods that are/may be required by the other controllers down the line
    /// </summary>
    public abstract class BaseController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BaseController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        protected string GetIpAddress()
        {
            return $"{_httpContextAccessor.HttpContext.Connection.RemoteIpAddress}:{_httpContextAccessor.HttpContext.Connection.RemotePort}";
        }
    }
}
