using CoffeeMakerApi.Middlewares;
using CoffeeMakerApi.ServiceContracts;
using CoffeeMakerApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace CoffeeMakerApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureInjectionServices(services);

            services.AddControllers();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Coffee Maker Api",
                    Description = "Api to get your coffee brewed",
                    Contact = new OpenApiContact
                    {
                        Name = "Ajay Kumar",
                        Email = string.Empty,
                    }
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            //Place holder for the CORS option in the future
            services.AddCors(options =>
            {
                options.AddPolicy("WhiteList", policy =>
                {
                    policy
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .WithExposedHeaders("WWW-Authenticate");
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors("WhiteList");

            app.UseHttpsRedirection();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.)
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Coffee Maker Api V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseCoffeeMakerCallTracker();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        /// <summary>
        /// Dependency injection
        /// </summary>
        /// <param name="services"></param>
        private void ConfigureInjectionServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddSingleton<IApiCallTrackerService>(x => new ApiCallTrackerService(Configuration.GetValue<int>("503StatusCallCount", 1)));
            services.AddSingleton<IWeatherService>(x => new WeatherService(Configuration.GetValue<string>("WeatherApiUrl", "")));

            services.AddScoped<IBrewCoffeeService, BrewCoffeeService>();
        }
    }
}
