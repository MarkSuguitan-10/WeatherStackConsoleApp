using WeatherStackLibrary.Model;
using System.Linq;

namespace WeatherStackLibrary.Process
{
    public class CanGoOutside : IResponse
    {
        public string Respond(IWeatherModel model)
        {
            string output = string.Empty;
            if (WeatherConditions.RainWeatherConditions.Intersect(model.Weather_Descriptions).Any() == true)
            {
                output = "No, It is  raining.";
            }
            else
            {
                output = "Yes, It is not raining.";
            }
            return output;

        }
    }
}
