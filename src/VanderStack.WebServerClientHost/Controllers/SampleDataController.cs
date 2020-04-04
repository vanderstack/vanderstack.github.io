using VanderStack.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VanderStack.WebServerClientHost.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        public SampleDataController(IWeatherForecastService weatherForecastService)
        {
            WeatherForecastService = weatherForecastService;
        }

        protected IWeatherForecastService WeatherForecastService { get; }

        [HttpGet("[action]")]
        public async Task<IEnumerable<WeatherForecast>> WeatherForecasts()
        {
            return await WeatherForecastService.GetAsync();
        }
    }
}
