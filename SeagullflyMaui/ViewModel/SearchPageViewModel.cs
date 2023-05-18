using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SeagullflyMaui.Enums;
using SeagullflyMaui.Interfaces;
using SeagullflyMaui.Model;
using SeagullflyMaui.View;

namespace SeagullflyMaui.ViewModel;
public partial class SearchPageViewModel : BaseViewModel
{
    private readonly IAiportsService _aiportsService;
    private readonly ISearchQueryService _searchQueryService;

    [ObservableProperty]
    private List<SearchQuery> savedQuerries;
    [ObservableProperty]
    private List<Airport> airports;
    [ObservableProperty]
    private string from;
    [ObservableProperty]
    private string to;
    [ObservableProperty]
    private DateTime departure;
    [ObservableProperty]
    private DateTime arrival;
    [ObservableProperty]
    List<string> flightTypes;
    [ObservableProperty]
    int selectedFlightTypeIndex;
    [ObservableProperty]
    int adultCount = 1;
    [ObservableProperty]
    int youthCount = 0;
    [ObservableProperty]
    int childrenCount = 0;
    [ObservableProperty]
    int infantCount = 0;
    [ObservableProperty]
    bool queryLoaded = false;
    [ObservableProperty]
    bool btnSaveEnabled = true;

    public SearchPageViewModel(IAiportsService aiportsService, ISearchQueryService searchQueryService)
	{
		Title = "SEAGULLFLY";
        _aiportsService = aiportsService;
        _searchQueryService = searchQueryService;
        FlightTypes = new ()
        {
            FlightType.OneWay.ToString(),
            FlightType.OneWayDirect.ToString(),
            FlightType.TwoWays.ToString(),
            FlightType.TwoWaysDirect.ToString()
        };
        SavedQuerries = _searchQueryService.GetSavedQuerries();
    }

    [RelayCommand]
    async Task InitAsync()
    {
        try
        {
            Airports = await _aiportsService.GetAirports();
        }
        catch
        {
            Airports = new List<Airport>();
        }
    }

    [RelayCommand]
    async Task SearchFlights()
    {
        await Shell.Current.GoToAsync(nameof(FlightsResultsPage), true, new Dictionary<string, object>
        {
            {
                "Query",
                GetSearchQuery()
            }
        });
    }

    [RelayCommand]
    void SaveQuerry()
    {
        _searchQueryService.SaveQuery(GetSearchQuery());
    }

    [RelayCommand]
    void ChangeAdultCount(string change)
    {
        var newValue = Math.Clamp(AdultCount += int.Parse(change), 0, 10);
        if (newValue != AdultCount)
        {
            QueryLoaded = false;
            BtnSaveEnabled = true;
        }  
        AdultCount = newValue; 
    }

    [RelayCommand]
    void ChangeYouthCount(string change)
    {
        var newValue = Math.Clamp(YouthCount += int.Parse(change), 0, 10);
        if (newValue != YouthCount)
        {
            QueryLoaded = false;
            BtnSaveEnabled = true;
        }
        YouthCount = newValue;
    }

    [RelayCommand]
    void ChangeChildrenCount(string change)
    {
        var newValue = Math.Clamp(ChildrenCount += int.Parse(change), 0, 10);
        if (newValue != ChildrenCount)
        {
            QueryLoaded = false;
            BtnSaveEnabled = true;
        }
        ChildrenCount = newValue;
    }

    [RelayCommand]
    void ChangeInfantCount(string change)
    {
        var newValue = Math.Clamp(InfantCount += int.Parse(change), 0, 10);
        if (newValue != InfantCount)
        {
            QueryLoaded = false;
            BtnSaveEnabled = true;
        }
        InfantCount = newValue;
    }

    private SearchQuery GetSearchQuery()
    {
        return new SearchQuery()
        {
            To = To,
            From = From,
            Departure = Departure,
            Arrival = Arrival,
            FlightType = FlightTypes[SelectedFlightTypeIndex],
            AdultCount = AdultCount,
            YouthCount = YouthCount,
            ChildrenCount = ChildrenCount,
            InfantCount = InfantCount
        };
    }
}
