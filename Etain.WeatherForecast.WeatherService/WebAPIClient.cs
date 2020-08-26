using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Etain.WeatherForecast.WeatherService
{
    public static class WebAPIClient
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task<string> GetResourceAsync(string url)
        {
            try
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Add("User-Agent", "Etain Weather Forecast App");

                var responseTask = client.GetStringAsync(url);

                var responseData = await responseTask;

                return responseData;

            } catch(Exception ex)
            {
                return string.Empty;
            }
           
        }
    }
}
