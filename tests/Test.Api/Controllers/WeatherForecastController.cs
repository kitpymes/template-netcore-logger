using Kitpymes.Core.Logger.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private ILogger Logger { get; }

        public WeatherForecastController(ILoggerService logger)
        {
            Logger = logger.CreateLogger<WeatherForecastController>();
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            Logger
               .Info("Get Summaries")
               .Info(message: "Summary 1", Summaries[0])
               .Info(message: "Summary 2", Summaries[1])
               .Info(message: "Summary 3", Summaries[2])
               .Info(message: "All Summaries", Summaries)
               .Error("Error Summaries");

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
