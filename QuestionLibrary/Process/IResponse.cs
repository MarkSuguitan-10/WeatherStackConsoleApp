using WeatherStackLibrary.Questions;
using WeatherStackLibrary.Model;

namespace WeatherStackLibrary.Process
{
    public interface IResponse
    {
        string Respond(IWeatherModel model);
    }
}
