using SeagullflyMaui.Interfaces;
using SeagullflyMaui.Model;

namespace SeagullflyMaui.Services;
public class WeatherService : IWeatherService
{
    public WeatherResult GetWeatherInfo(string place, DateTime date)
    {
        return new WeatherResult()
        {
            RainProbability = new Random().Next(0,100).ToString(),
            Humidity = new Random().Next(0, 100).ToString(),
            Wind = new Random().Next(0, 30).ToString(),
            Temperature = new Random().Next(0, 40).ToString(),
        };
    }
}
