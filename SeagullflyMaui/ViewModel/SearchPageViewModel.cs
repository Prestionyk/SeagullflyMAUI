using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SeagullflyMaui.Interfaces;
using SeagullflyMaui.Model;
using SeagullflyMaui.View;

namespace SeagullflyMaui.ViewModel;
public partial class SearchPageViewModel : BaseViewModel
{
    private readonly IAiportsService _aiportsService;
    private readonly Task initTask;

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

    public SearchPageViewModel(IAiportsService aiportsService)
	{
		Title = "SEAGULLFLY";
        _aiportsService = aiportsService;
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
        await Shell.Current.GoToAsync(nameof(FlightsResultsPage));
    }

    [RelayCommand]
    void ChangeAdultCount(string change)
    {
        AdultCount = Math.Clamp(AdultCount += int.Parse(change), 0, 10); 
    }

    [RelayCommand]
    void ChangeYouthCount(string change)
    {
        YouthCount = Math.Clamp(YouthCount += int.Parse(change), 0, 10);
    }

    [RelayCommand]
    void ChangeChildrenCount(string change)
    {
        ChildrenCount = Math.Clamp(ChildrenCount += int.Parse(change), 0, 10);
    }

    [RelayCommand]
    void ChangeInfantCount(string change)
    {
        InfantCount = Math.Clamp(InfantCount += int.Parse(change), 0, 10);
    }
}
