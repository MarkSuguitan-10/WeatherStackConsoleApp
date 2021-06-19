using System.Collections.Generic;

namespace WeatherStackLibrary.Model
{
    public interface IWeatherModel
    {
        string Cloudcover { get; set; }
        string FeelsLike { get; set; }
        string Humidity { get; set; }
        string Is_Day { get; set; }
        bool IsSuccess { get; set; }
        string Observation_Time { get; set; }
        string Precip { get; set; }
        string Pressure { get; set; }
        string Temperature { get; set; }
        string UV_Index { get; set; }
        string Visibility { get; set; }
        string Weather_Code { get; set; }
        List<string> Weather_Descriptions { get; set; }
        List<string> Weather_Icons { get; set; }
        string Wind_Degree { get; set; }
        string Wind_Dir { get; set; }
        string Wind_Speed { get; set; }
    }
}