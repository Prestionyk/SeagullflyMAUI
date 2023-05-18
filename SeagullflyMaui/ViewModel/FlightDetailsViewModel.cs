using CommunityToolkit.Mvvm.ComponentModel;
using SeagullflyMaui.Interfaces;
using SeagullflyMaui.Model;

namespace SeagullflyMaui.ViewModel;

[QueryProperty(nameof(SearchQuery), "Query")]
public partial class FlightDetailsViewModel :BaseViewModel
{
    private readonly IWeatherService _weatherService;

    [ObservableProperty]
    private SearchQuery searchQuery;

    public FlightDetailsViewModel(IWeatherService weatherService)
	{
		Title = "SEAGULLFLY";
        _weatherService = weatherService;
	}
}
