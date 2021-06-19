using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherStackLibrary.Model;
using WeatherStackLibrary;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


namespace WeatherStackLibrary.APIController
{
    /// <summary>
    /// class acting as controller for making get call on URL.
    /// </summary>
    public class CallWeatherAPI
    {
        /// <summary>
        /// Get Weather Stack Data from API
        /// </summary>
        /// <param name="zipCode">State location in US</param>
        /// <param name="APIUrl">Weatherstack URL</param>
        /// <param name="access_key">Access Key provided by weather Stack.</param>
        /// <returns></returns>
        /// A5:2017-Broken Access Control added validation
        [HttpGet]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public static async Task<IWeatherModel> GetZipCodeWeatherData(IURL url)
        {
            ILogger logger = new Logger();
            WeatherModel data = new WeatherModel();
            try
            {
                //Set for security and memory management. 
                using (var client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(url.GetCurrentEndPoint());

                    if (response.IsSuccessStatusCode)
                    {
                        var readTask = response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        var rawResponse = JObject.Parse(readTask.GetAwaiter().GetResult());

                        //Encountered null error here.
                        var currentData = rawResponse["current"];
                        data = JsonConvert.DeserializeObject<WeatherModel>(currentData.ToString());
                        data.IsSuccess = true;
                    }
                    else
                    {
                        Console.WriteLine("Error Occured:{0}", response.StatusCode);
                    }
                }
            }
            catch (Exception ee)
            {
                logger.Log(ee.StackTrace);
                data.IsSuccess = false;
            }
            return data;
        }
    }
}
