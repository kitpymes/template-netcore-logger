using Core.Logger.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private LoggerService Logger { get; }

        public WeatherForecastController(ILoggerService logger)
        {
            Logger = logger.CreateLogger<WeatherForecastController>();
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            // Enable and customize logger in appsettings, or in Startup class.
            Logger
                .Info("Get Summaries")
                .Info("Summary 1", Summaries[0])
                .Info("Summary 2", Summaries[1])
                .Info("Summary 3", Summaries[2])
                .Info("All Summaries", Summaries);

            var rng = new Random();

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
