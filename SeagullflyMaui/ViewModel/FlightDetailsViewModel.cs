using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SeagullflyMaui.Interfaces;
using SeagullflyMaui.Model;

namespace SeagullflyMaui.ViewModel;

[QueryProperty(nameof(FlightOffer), "Data")]
public partial class FlightDetailsViewModel :BaseViewModel
{
    [ObservableProperty]
    private int price;
    [ObservableProperty]
    private string carrier;
    [ObservableProperty]
    private string rain;
    [ObservableProperty]
    private string humidity;
    [ObservableProperty]
    private string wind;
    [ObservableProperty]
    private string temperature;
    [ObservableProperty]
    private List<Travelling> travellings;
    [ObservableProperty]
    private FlightOffer flightOffer;

    private readonly IWeatherService _weatherService;

    public FlightDetailsViewModel(IWeatherService weatherService)
	{
		Title = "SEAGULLFLY";
        _weatherService = weatherService;
	}

    public void LoadDetails()
    {
        var weather = _weatherService.GetWeatherInfo(FlightOffer.Travellings.Last().To, DateTime.Now);
        Travellings = FlightOffer.Travellings;
        Price = FlightOffer.FullCost;
        Carrier = FlightOffer.Carrier;
        Rain = weather.RainProbability;
        Humidity = weather.Humidity;
        Wind = weather.Wind;
        Temperature = weather.Temperature;
    }

    [RelayCommand]
    void ObserveOffert()
    {
        
    }

    [RelayCommand]
    async Task OpenOffert()
    {
        await Browser.Default.OpenAsync(FlightOffer.Url, BrowserLaunchMode.SystemPreferred);
    }
}
