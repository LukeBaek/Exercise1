using System;
using System.Collections.Generic;
using System.Text;

namespace Weather.Services.DTOs
{
    public class ForecastInfo
    {
        public List<DailyWeatherInfo> daily { get; set; }
    }

    public class Temp
    {
        public double day { get; set; }
    }
    public class Weather
    {
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }

    }
    public class DailyWeatherInfo
    {
        public long dt { get; set; }
        public Temp temp { get; set; }
        public List<Weather> weather { get; set; }
    }
}
