using System.Linq;
using System;
using WeatherStackLibrary.Model;

namespace WeatherStackLibrary.Process
{
    public class CanFlyKite : IResponse
    {
        public string Respond(IWeatherModel data)
        {
            string output = string.Empty;
            if (WeatherConditions.RainWeatherConditions.Intersect(data.Weather_Descriptions).Any() == true && Convert.ToInt32(data.Wind_Speed) < 15)
            {
                output = "No, It is raining and windspeed is " + data.Wind_Speed + ".";
            }
            else if (WeatherConditions.RainWeatherConditions.Intersect(data.Weather_Descriptions).Any() == true)
            {
                output =  "No, It is raining!";
            }
            else if (Convert.ToInt32(data.Wind_Speed) < 15)
            {
                output = "No, Windspeed is " + data.Wind_Speed + "."; 
            }
            else
            {
                output = "Yes, It is perfect weather condition to fly kite.";
            }
            return output;
        }
    }
}
