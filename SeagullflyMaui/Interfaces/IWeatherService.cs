using SeagullflyMaui.Model;

namespace SeagullflyMaui.Interfaces;
public interface IWeatherService
{
    WeatherResult GetWeatherInfo(string place, DateTime date);
}
