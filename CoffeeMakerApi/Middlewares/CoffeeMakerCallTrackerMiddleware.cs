using CoffeeMakerApi.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System.Threading.Tasks;

namespace CoffeeMakerApi.Middlewares
{
    public class CoffeeMakerCallTrackerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IApiCallTrackerService _apiCallTracker;

        public CoffeeMakerCallTrackerMiddleware(RequestDelegate next, IApiCallTrackerService apiCallTracker)
        {
            _next = next;
            _apiCallTracker = apiCallTracker;
        }

        public async Task Invoke(HttpContext context)
        {
            RouteEndpoint route = (RouteEndpoint)context.GetEndpoint();
            if(route.RoutePattern.RawText.Contains("brew-coffee", System.StringComparison.InvariantCultureIgnoreCase))
            {
                _apiCallTracker.IncrementApiCallCount();
                if(_apiCallTracker.ApiShouldReturnUnavailable())
                {
                    context.Response.StatusCode = StatusCodes.Status503ServiceUnavailable;
                }
                else
                {
                    await _next.Invoke(context);
                }
            }
            else
            {
                await _next.Invoke(context);
            }
        }
    }
}
