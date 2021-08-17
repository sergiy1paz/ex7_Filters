using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ex7_Filters.Filters;
using ex7_Filters.Exceptions;

namespace ex7_Filters.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [TypeFilter(typeof(CustomAuthorizationFilter))]
        [TypeFilter(typeof(EvenIntNumberExceptionFilter))]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();

            EvenIntNumberException.CheckNumber(rng.Next(1, 10));

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }


        [HttpGet("test")]
        [TypeFilter(typeof(TestActionFilter1), Order = 2)]
        [TypeFilter(typeof(TestActionFilter2), Order = 1)]
        public IActionResult TestOrderSameFilters()
        {
            return Ok("Everything is good!");
        }
    }
}
