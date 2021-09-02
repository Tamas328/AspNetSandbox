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
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public WeatherForecastController()
        {
        }

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

        public IEnumerable<WeatherForecast> ConvertResponseToWeatherForecast(string content)
        {
            var json = JObject.Parse(content);
            var jsonDailyForecast = json["daily"][1];
            var unixDateTime = jsonDailyForecast.Value<long>("dt");

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTimeOffset.FromUnixTimeSeconds(unixDateTime).Date,
                TemperatureC = (int)(jsonDailyForecast["temp"].Value<double>("day") - 273.15f),
                Summary = jsonDailyForecast["weather"][0].Value<string>("main")
            }).ToArray();
        }
    }
}
