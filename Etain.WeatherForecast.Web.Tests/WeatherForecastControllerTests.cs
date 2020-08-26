using Etain.WeatherForecast.Domain;
using Etain.WeatherForecast.Infrastructure.Interfaces;
using Etain.WeatherForecast.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace Etain.WeatherForecast.Web.Tests
{
    [TestClass]
    public class WeatherForecastControllerTests
    {
        private readonly WeatherForecastController _classInTest;
        private readonly Mock<IWeatherService> _weatherService;

        public WeatherForecastControllerTests()
        {
            _weatherService = new Mock<IWeatherService>();
            _classInTest = new WeatherForecastController(_weatherService.Object);
            
        }
        [TestMethod]
        public void Get_Calls_WeatherService_GetWeatherForecastsForLocation()
        {
            _weatherService.Setup(x => x.GetWeatherForecastsForLocation("")).Verifiable();
            _classInTest.Get("");
            _weatherService.Verify(x => x.GetWeatherForecastsForLocation(""), Times.Once());
        }

        [TestMethod]
        public void Get_ReturnsWeather()
        {
            var expectedWeather = new Weather
            {
                Title = "Belfast",
                WeatherForecast = new List<Forecast> 
                {
                    new Forecast
                    {
                        Id = 343433,
                        StateName = "Snow"
                    }
                }

            };

            _weatherService.Setup(x => x.GetWeatherForecastsForLocation("")).Returns(expectedWeather);
            var actualWeather = _classInTest.Get("");

            Assert.AreEqual(expectedWeather, actualWeather);
        }
    }
}
