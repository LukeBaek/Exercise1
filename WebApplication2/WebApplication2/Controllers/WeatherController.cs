using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Weather.Services;
using Weather.Services.DTOs;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        public WeatherController()
        {
            _weatherService = new WeatherService();
        }

        [HttpGet("get")]
        public ActionResult<ForecastInfo> GetWeather(double latitude, double longitude)
        {
            return _weatherService.GetWeather(latitude, longitude);

        }


        private WeatherService _weatherService;
    }
}
