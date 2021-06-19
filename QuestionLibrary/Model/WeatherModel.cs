using System;
using System.Collections.Generic;

namespace WeatherStackLibrary.Model
{
    /// <summary>
    /// Simple model to match the {current} json response. 
    /// </summary>
    public class WeatherModel : IWeatherModel
    {
        public string Observation_Time { get; set; }
        public string Temperature { get; set; }
        public string Weather_Code { get; set; }
        public List<string> Weather_Icons { get; set; }
        public List<string> Weather_Descriptions { get; set; }
        public string Wind_Speed { get; set; }
        public string Wind_Degree { get; set; }
        /// <summary>
        /// Wind Direction
        /// </summary>
        public string Wind_Dir { get; set; }
        public string Pressure { get; set; }
        /// <summary>
        /// Precipitation
        /// </summary>
        public string Precip { get; set; }
        public string Humidity { get; set; }
        public string Cloudcover { get; set; }
        public string FeelsLike { get; set; }
        public string UV_Index { get; set; }
        public string Visibility { get; set; }
        public string Is_Day { get; set; }
        public bool IsSuccess { get; set; } = false;
    }
}
