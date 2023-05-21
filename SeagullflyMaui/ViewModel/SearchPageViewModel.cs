using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SeagullflyMaui.DTOs;
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
    private List<SearchQueryDto> savedQuerries;
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
    [ObservableProperty]
    SearchQueryDto selectedQuery;

    public SearchPageViewModel(IAiportsService aiportsService, ISearchQueryService searchQueryService)
	{
		Title = "SEAGULLFLY";
        _aiportsService = aiportsService;
        _searchQueryService = searchQueryService;
        Arrival = DateTime.Now;
        Departure = DateTime.Now;
        try
        {
            FlightTypes = new()
            {
                FlightType.OneWay.ToPolishString(),
                FlightType.OneWayDirect.ToPolishString(),
                FlightType.TwoWays.ToPolishString(),
                FlightType.TwoWaysDirect.ToPolishString()
            };
        }
        catch
        {
            Application.Current.MainPage.DisplayAlert("Error", "Error occured in constructor", "Ok");
        }
    }

    public async Task InitAsync()
    {
        try
        {
            if (Airports is null)
            {
                Airports = await _aiportsService.GetAirports();
                SavedQuerries = await _searchQueryService.GetSavedQuerries();
            }    
        }
        catch (Exception ex)
        {
            Airports = new List<Airport>();
            await Application.Current.MainPage.DisplayAlert("Error", $"Error occured in init: {ex.Message}|{ex.InnerException.Message}", "Ok");
        }
    }

    [RelayCommand]
    async Task SearchFlights()
    {
        if (From is null || To is null)
        {
            await Application.Current.MainPage.DisplayAlert("Uwaga", $"Uzupełnij wszystkie kryteria wyszukiwania", "Ok");
            return;
        }
        var currentQuery = GetSearchQuery();
        await Shell.Current.GoToAsync(nameof(FlightsResultsPage), true, new Dictionary<string, object>
        {
            {
                "Data",
                currentQuery
            }
        });
    }

    [RelayCommand]
    async Task SaveQuerry()
    {
        if (From is null || To is null)
        {
            await Application.Current.MainPage.DisplayAlert("Uwaga", $"Uzupełnij wszystkie kryteria wyszukiwania", "Ok");
            return;
        }

        var name = await Application.Current.MainPage.DisplayPromptAsync("Zapisywanie", "Wprowadź nazwę", "Zapisz", "Anuluj", "Nazwa");
        if (name is null)
            return;
        if (SavedQuerries.Any(qu => qu.Name == name))
        {
            await Application.Current.MainPage.DisplayAlert("Uwaga", $"Ta nazwa jest już zajęta", "Ok");
            return;
        }

        var queryToSave = GetSearchQuery();
        queryToSave.Name = name;

        await _searchQueryService.SaveQuery(queryToSave);

        await Application.Current.MainPage.DisplaySnackbar("Filtr zapisany");

        SavedQuerries = await _searchQueryService.GetSavedQuerries();
    }

    [RelayCommand]
    async Task DeleteSavedQuery()
    {
        await _searchQueryService.DeleteQuery(SelectedQuery.Id);
        SavedQuerries = await _searchQueryService.GetSavedQuerries();

        await Application.Current.MainPage.DisplaySnackbar("Filtr usunięty");
    }

    [RelayCommand]
    void ChangeAdultCount(string change)
    {
        var newValue = Math.Clamp(AdultCount + int.Parse(change), 0, 10);
        if (newValue != AdultCount)
        {
            QueryLoaded = false;
            BtnSaveEnabled = true;
            SelectedQuery = null;
        }  
        AdultCount = newValue; 
    }

    [RelayCommand]
    void ChangeYouthCount(string change)
    {
        var newValue = Math.Clamp(YouthCount + int.Parse(change), 0, 10);
        if (newValue != YouthCount)
        {
            QueryLoaded = false;
            BtnSaveEnabled = true;
            SelectedQuery = null;
        }
        YouthCount = newValue;
    }

    [RelayCommand]
    void ChangeChildrenCount(string change)
    {
        var newValue = Math.Clamp(ChildrenCount + int.Parse(change), 0, 10);
        if (newValue != ChildrenCount)
        {
            QueryLoaded = false;
            BtnSaveEnabled = true;
            SelectedQuery = null;
        }
        ChildrenCount = newValue;
    }

    [RelayCommand]
    void ChangeInfantCount(string change)
    {
        var newValue = Math.Clamp(InfantCount + int.Parse(change), 0, 10);
        if (newValue != InfantCount)
        {
            QueryLoaded = false;
            BtnSaveEnabled = true;
            SelectedQuery = null;
        }
        InfantCount = newValue;
    }

    private SearchQueryDto GetSearchQuery()
    {
        return new SearchQueryDto()
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
