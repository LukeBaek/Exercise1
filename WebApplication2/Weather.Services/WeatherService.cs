using Newtonsoft.Json;
using System;
using System.Net;
using Weather.Services.DTOs;

namespace Weather.Services
{
    public class WeatherService : IDisposable
    {
        public WeatherService()
        {
            _webClient = new WebClient();
        }

        public ForecastInfo GetWeather(double latitude, double longitude)
        {
            var url = $"https://api.openweathermap.org/data/2.5/onecall?lat={latitude}&lon=-{longitude}&units=metric&exclude=hourly,current,minutely,alerts&appid={_apiKey}";
            var json = GetPayload(url);
            return JsonConvert.DeserializeObject<ForecastInfo>(json);
        }

        private string GetPayload(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                throw new InvalidOperationException("Url not provided");

            return _webClient.DownloadString(url);
        }

        public void Dispose()
        {
            _webClient?.Dispose();
        }

        private WebClient _webClient;
        private readonly string _apiKey = "6727351f42782346f4b725e4c994ae89";
    }
}
