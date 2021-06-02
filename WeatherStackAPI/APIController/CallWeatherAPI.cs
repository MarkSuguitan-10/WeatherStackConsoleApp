using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherStackAPI.APIController;
using WeatherStackAPI.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WeatherStackAPI.APIController
{
    /// <summary>
    /// class acting as controller for making get call on URL.
    /// </summary>
    static class CallWeatherAPI
    {
        /// <summary>
        /// Get Weather Stack Data from API
        /// </summary>
        /// <param name="zipCode">State location in US</param>
        /// <param name="APIUrl">Weatherstack URL</param>
        /// <param name="access_key">Access Key provided by weather Stack.</param>
        /// <returns></returns>
        public static async Task<WeatherModel> GetZipCodeWeatherData()
        {
            WeatherModel data = new WeatherModel();
            try
            {
                //Set for security and memory management. 
                using (var client = new HttpClient())
                {
                    
                    HttpResponseMessage response = await client.GetAsync(URL.NewURL);

                    if (response.IsSuccessStatusCode)
                    {
                        var readTask = response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        var rawResponse = JObject.Parse(readTask.GetAwaiter().GetResult());

                        var currentData = rawResponse["current"];
                        data = JsonConvert.DeserializeObject<WeatherModel>(currentData.ToString());
                        data.IsSuccess = true;
                    }
                    else
                    {
                        Console.WriteLine("Error Occured:{0}",response.StatusCode);
                    }
                }
            }
            catch (Exception ee)
            {
                data.IsSuccess = false;
               //Log error in a separate file.
            }
            return data;
        }

        
       
    }
}
