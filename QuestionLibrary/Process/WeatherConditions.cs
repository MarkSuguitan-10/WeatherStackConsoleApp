using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherStackLibrary.Process
{
    public class WeatherConditions
    {
        /// <summary>
        /// List of weather conditions provided by WeatherStackLibrary
        /// </summary>
        public static List<string> AllWeatherConditions = new List<string>() {
            "Sunny",
            "Partly cloudy",
            "Cloudy",
            "Overcast",
            "Mist",
            "Patchy rain possible",
            "Patchy snow possible",
            "Patchy sleet possible",
            "Patchy freezing drizzle possible",
            "Thundery outbreaks possible",
            "Blowing snow",
            "Blizzard",
            "Fog",
            "Freezing fog",
            "Patchy light drizzle",
            "Light drizzle",
            "Freezing drizzle",
            "Heavy freezing drizzle",
            "Patchy light rain",
            "Light rain",
            "Moderate rain at times",
            "Moderate rain",
            "Heavy rain at times",
            "Heavy rain",
            "Light freezing rain"
        };

        //Only weather conditions with rain word qualifies as rain weather conditions.
        public static List<string> RainWeatherConditions = new List<string>() { 
            "Patchy rain possible", 
            "Patchy light rain", 
            "Light rain", 
            "Moderate rain at times",
            "Moderate rain", 
            "Heavy rain at times", 
            "Heavy rain", 
            "Light freezing rain" };
    }
}
