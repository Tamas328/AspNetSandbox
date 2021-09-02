using AspNetSandbox;
using AspNetSandbox.Controllers;
using System;
using System.IO;
using Xunit;

namespace AspNetSandbox.Tests
{
    public class WeatherForecastControllerTest
    {
        [Fact]
        public void ConvertResponseToWeatherForecastTest()
        {
            // Assume
            string content = LoadJsonFromResource();
            var controller = new WeatherForecastController();

            // Act
            var output = controller.ConvertResponseToWeatherForecast(content);

            // Assert
            WeatherForecast weatherForecastTomorrow = ((WeatherForecast[])output)[0];
            Assert.Equal("Clear", weatherForecastTomorrow.Summary);
            Assert.Equal(21, weatherForecastTomorrow.TemperatureC);
            Assert.Equal(new DateTime(2021, 09, 03), weatherForecastTomorrow.Date);
        }

        [Fact]
        public void ConvertResponseToWeatherForecastAfterTomorrowTest()
        {
            // Assume
            string content = LoadJsonFromResource();
            var controller = new WeatherForecastController();

            // Act
            var output = controller.ConvertResponseToWeatherForecast(content);

            // Assert
            WeatherForecast weatherForecastAfterTomorrow = ((WeatherForecast[])output)[1];
            Assert.Equal("Clear", weatherForecastAfterTomorrow.Summary);
            Assert.Equal(23, weatherForecastAfterTomorrow.TemperatureC);
            Assert.Equal(new DateTime(2021, 09, 04), weatherForecastAfterTomorrow.Date);
        }

        private string LoadJsonFromResource()
        {
            var assembly = this.GetType().Assembly;
            var assemblyName = assembly.GetName().Name;
            var resourceName = $"{assemblyName}.DataFromOpenweatherApi.json";
            var resourceStream = assembly.GetManifestResourceStream(resourceName);
            using var tr = new StreamReader(resourceStream);
            return tr.ReadToEnd();
        }
    }
}
