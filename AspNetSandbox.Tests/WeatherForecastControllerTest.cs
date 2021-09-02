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
            Assert.Equal(20, weatherForecastTomorrow.TemperatureC);
            Assert.Equal(new DateTime(2021, 09, 03), weatherForecastTomorrow.Date);
        }

        [Fact]
        public void ConvertResponseToWeatherForecastAfterTomorrowTest()
        {
            // Assume
            string content = "{\"lat\":46.3101,\"lon\":23.7213,\"timezone\":\"Europe/Bucharest\",\"timezone_offset\":10800,\"current\":{\"dt\":1630565272,\"sunrise\":1630554411,\"sunset\":1630602192,\"temp\":287.64,\"feels_like\":286.71,\"pressure\":1021,\"humidity\":60,\"dew_point\":279.98,\"uvi\":1.79,\"clouds\":100,\"visibility\":10000,\"wind_speed\":2.61,\"wind_deg\":288,\"wind_gust\":5.89,\"weather\":[{\"id\":804,\"main\":\"Clouds\",\"description\":\"overcast clouds\",\"icon\":\"04d\"}]},\"daily\":[{\"dt\":1630576800,\"sunrise\":1630554411,\"sunset\":1630602192,\"moonrise\":1630534620,\"moonset\":1630594320,\"moon_phase\":0.84,\"temp\":{\"day\":290.36,\"min\":284.32,\"max\":292.85,\"night\":285.37,\"eve\":290.92,\"morn\":285.31},\"feels_like\":{\"day\":289.52,\"night\":284.55,\"eve\":290.19,\"morn\":284.59},\"pressure\":1021,\"humidity\":53,\"dew_point\":280.71,\"wind_speed\":6.2,\"wind_deg\":333,\"wind_gust\":9.54,\"weather\":[{\"id\":804,\"main\":\"Clouds\",\"description\":\"overcast clouds\",\"icon\":\"04d\"}],\"clouds\":100,\"pop\":0.09,\"uvi\":4.92},{\"dt\":1630663200,\"sunrise\":1630640886,\"sunset\":1630688477,\"moonrise\":1630624320,\"moonset\":1630683360,\"moon_phase\":0.88,\"temp\":{\"day\":293.78,\"min\":282.94,\"max\":295.44,\"night\":287.54,\"eve\":293.25,\"morn\":282.94},\"feels_like\":{\"day\":293.05,\"night\":286.84,\"eve\":292.67,\"morn\":282.94},\"pressure\":1021,\"humidity\":44,\"dew_point\":280.5,\"wind_speed\":2.07,\"wind_deg\":268,\"wind_gust\":3.06,\"weather\":[{\"id\":800,\"main\":\"Clear\",\"description\":\"clear sky\",\"icon\":\"01d\"}],\"clouds\":1,\"pop\":0,\"uvi\":5.13},{\"dt\":1630749600,\"sunrise\":1630727361,\"sunset\":1630774762,\"moonrise\":1630714620,\"moonset\":1630771920,\"moon_phase\":0.91,\"temp\":{\"day\":295.94,\"min\":284.6,\"max\":297.06,\"night\":292.17,\"eve\":294.73,\"morn\":284.6},\"feels_like\":{\"day\":295.4,\"night\":291.54,\"eve\":294.25,\"morn\":283.86},\"pressure\":1017,\"humidity\":43,\"dew_point\":281.99,\"wind_speed\":2.01,\"wind_deg\":83,\"wind_gust\":2.72,\"weather\":[{\"id\":800,\"main\":\"Clear\",\"description\":\"clear sky\",\"icon\":\"01d\"}],\"clouds\":0,\"pop\":0,\"uvi\":4.84},{\"dt\":1630836000,\"sunrise\":1630813837,\"sunset\":1630861046,\"moonrise\":1630805220,\"moonset\":1630860180,\"moon_phase\":0.94,\"temp\":{\"day\":295.06,\"min\":287.05,\"max\":297.58,\"night\":291.16,\"eve\":294.11,\"morn\":287.05},\"feels_like\":{\"day\":294.56,\"night\":290.58,\"eve\":293.62,\"morn\":286.43},\"pressure\":1019,\"humidity\":48,\"dew_point\":282.84,\"wind_speed\":2.86,\"wind_deg\":69,\"wind_gust\":5.15,\"weather\":[{\"id\":500,\"main\":\"Rain\",\"description\":\"light rain\",\"icon\":\"10d\"}],\"clouds\":18,\"pop\":0.28,\"rain\":0.1,\"uvi\":4.65},{\"dt\":1630922400,\"sunrise\":1630900312,\"sunset\":1630947329,\"moonrise\":1630896060,\"moonset\":1630948080,\"moon_phase\":0.98,\"temp\":{\"day\":291.5,\"min\":284.86,\"max\":295.31,\"night\":288.97,\"eve\":294.18,\"morn\":284.86},\"feels_like\":{\"day\":290.85,\"night\":288.25,\"eve\":293.64,\"morn\":283.94},\"pressure\":1024,\"humidity\":56,\"dew_point\":281.88,\"wind_speed\":3.77,\"wind_deg\":156,\"wind_gust\":3.97,\"weather\":[{\"id\":804,\"main\":\"Clouds\",\"description\":\"overcast clouds\",\"icon\":\"04d\"}],\"clouds\":94,\"pop\":0.23,\"uvi\":4.16},{\"dt\":1631008800,\"sunrise\":1630986787,\"sunset\":1631033613,\"moonrise\":1630986900,\"moonset\":1631035800,\"moon_phase\":0,\"temp\":{\"day\":294.14,\"min\":284.33,\"max\":297.17,\"night\":291.19,\"eve\":296.49,\"morn\":284.33},\"feels_like\":{\"day\":293.47,\"night\":290.33,\"eve\":295.82,\"morn\":283.67},\"pressure\":1024,\"humidity\":45,\"dew_point\":281.06,\"wind_speed\":2.19,\"wind_deg\":71,\"wind_gust\":2.58,\"weather\":[{\"id\":800,\"main\":\"Clear\",\"description\":\"clear sky\",\"icon\":\"01d\"}],\"clouds\":3,\"pop\":0,\"uvi\":5},{\"dt\":1631095200,\"sunrise\":1631073263,\"sunset\":1631119895,\"moonrise\":1631077860,\"moonset\":1631123520,\"moon_phase\":0.05,\"temp\":{\"day\":294.02,\"min\":285.49,\"max\":296.36,\"night\":290.76,\"eve\":296.36,\"morn\":285.49},\"feels_like\":{\"day\":293.23,\"night\":289.8,\"eve\":295.6,\"morn\":284.58},\"pressure\":1019,\"humidity\":41,\"dew_point\":279.8,\"wind_speed\":2.12,\"wind_deg\":187,\"wind_gust\":3.31,\"weather\":[{\"id\":804,\"main\":\"Clouds\",\"description\":\"overcast clouds\",\"icon\":\"04d\"}],\"clouds\":99,\"pop\":0,\"uvi\":5},{\"dt\":1631181600,\"sunrise\":1631159738,\"sunset\":1631206178,\"moonrise\":1631168880,\"moonset\":1631211240,\"moon_phase\":0.08,\"temp\":{\"day\":295.61,\"min\":287.69,\"max\":297.01,\"night\":291.76,\"eve\":296.31,\"morn\":287.69},\"feels_like\":{\"day\":294.77,\"night\":291.06,\"eve\":295.67,\"morn\":286.56},\"pressure\":1016,\"humidity\":33,\"dew_point\":278.04,\"wind_speed\":2.15,\"wind_deg\":346,\"wind_gust\":2.99,\"weather\":[{\"id\":803,\"main\":\"Clouds\",\"description\":\"broken clouds\",\"icon\":\"04d\"}],\"clouds\":72,\"pop\":0.07,\"uvi\":5}]}";
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
