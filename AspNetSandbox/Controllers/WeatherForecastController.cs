using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace AspNetSandbox.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private const float KELVIN_CONST = 273.15f;


        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var client = new RestClient("https://api.openweathermap.org/data/2.5/onecall?lat=46.31006&lon=23.72128&exclude=hourly,minutely&appid=83e8bc6b93812cd218506b93687ee05e");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            return ConvertResponseToWeatherForecast(response.Content);
        }

        [NonAction]
        public IEnumerable<WeatherForecast> ConvertResponseToWeatherForecast(string content, int days = 5)
        {
            var json = JObject.Parse(content);   

            return Enumerable.Range(1, days).Select(index => {
                var jsonDailyWeather = json["daily"][index];
                var unixDateTime = jsonDailyWeather.Value<long>("dt");
                var weatherSummary = jsonDailyWeather["weather"][0].Value<string>("main");
                var weatherIcon = jsonDailyWeather["weather"][0].Value<string>("icon");

                return new WeatherForecast
                {
                    Date = DateTimeOffset.FromUnixTimeSeconds(unixDateTime).Date,
                    TemperatureC = ExtractCelsiusTemperatureFromDailyWeather(jsonDailyWeather),
                    Summary = weatherSummary,
                    Icon = weatherIcon
                };
            }).ToArray();
        }

        private static int ExtractCelsiusTemperatureFromDailyWeather(JToken jsonDailyWeather)
        {
            return (int)Math.Round(jsonDailyWeather["temp"].Value<double>("day") - KELVIN_CONST);
        }
    }
}
