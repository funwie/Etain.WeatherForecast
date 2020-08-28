using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Etain.WeatherForecast.WeatherService.Tests
{
    [TestClass]
    public class MetaWeatherServiceTests
    {
        private readonly MetaWeatherService _classInTest;

        public MetaWeatherServiceTests()
        {
            _classInTest = new MetaWeatherService();
        }


        [TestMethod]
        public void GetWeatherForecastsForLocation_Calls_WebAPIClient_GetResourceAsync()
        {

        }
    }
}
