using WeatherStackLibrary.Questions;
using System;
using System.Collections.Generic;
using System.Text;
using WeatherStackLibrary.Model;

namespace WeatherStackLibrary.Process
{
    public class CanWearSunscreen : IResponse
    {
        public string Respond(IWeatherModel data)
        {
            string output = string.Empty;
            if (Convert.ToInt32(data.UV_Index) > 3)
            {
                output = "Yes, you should wear sunscreen.";
            }
            else
            {
                output = "No, UV is only at" + data.UV_Index + ".";
            }
            return output;
        }
    }
}
