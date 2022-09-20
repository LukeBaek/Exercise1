using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Model
{

    public class WeatherInfo
    {
        public Coordinate Coordinate { get; set; }
        public List<Weather> Weather { get; set; }
        public WeatherSummary Main { get; set; }
        public Wind Wind { get; set; }
        public SunlightInfo SunlightInfo { get; set; }
    }

    public class Coordinate
    {
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
    public class Weather
    {
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }
    public class WeatherSummary
    {
        public double Temp { get; set; }
        public double Pressure { get; set; }
        public double Humidity { get; set; }
    }
    public class Wind
    {
        public double Speed { get; set; }
    }
    public class SunlightInfo
    {
        public long Sunrise { get; set; }
        public long Sunset { get; set; }
    }
}
