using CommunityToolkit.Mvvm.Input;
using MvvmHelpers;
using SeagullflyMaui.DTOs;
using SeagullflyMaui.Interfaces;
using SeagullflyMaui.Model;
using SeagullflyMaui.View;

namespace SeagullflyMaui.ViewModel;

[QueryProperty(nameof(SearchQueryDto), "Data")]
public partial class FlightsResultsViewModel : BaseViewModel
{
    public ObservableRangeCollection<FlightOffer> FlightOffers { get; } = new();
    public SearchQueryDto SearchQueryDto { get; set; }

    private readonly IFlightOffersService _flightOffersService;

	public FlightsResultsViewModel(IFlightOffersService flightOffersService)
	{
        Title = "SEAGULLFLY";
        _flightOffersService = flightOffersService;
    }

    public void LoadFlightOffers()
    {
        if (FlightOffers.Count == 0)
            FlightOffers.AddRange(_flightOffersService.GetFlightOffers(SearchQueryDto));
    }

    [RelayCommand]
    async Task FlightDetails(FlightOffer flightOffer)
    {
        await Shell.Current.GoToAsync(nameof(FlightDetailsPage), true, new Dictionary<string, object>
        {
            {
                "Data",
                flightOffer
            }
        });
    }
}
