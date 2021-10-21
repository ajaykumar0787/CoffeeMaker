using Microsoft.AspNetCore.Builder;

namespace CoffeeMakerApi.Middlewares
{
    public static class CoffeeMakerCallTrackerMiddlewareExtension
    {
        public static IApplicationBuilder UseCoffeeMakerCallTracker(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CoffeeMakerCallTrackerMiddleware>();
        }
    }
}
