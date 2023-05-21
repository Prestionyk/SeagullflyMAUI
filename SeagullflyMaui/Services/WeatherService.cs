using SeagullflyMaui.Interfaces;
using SeagullflyMaui.Model;

namespace SeagullflyMaui.Services;
public class WeatherService : IWeatherService
{
    public WeatherResult GetWeatherInfo(string place, DateTime date)
    {
        return new WeatherResult()
        {
            RainProbability = "50",
            Humidity = "90",
            Wind = "5",
            Temperature = "1",
        };
    }
}
