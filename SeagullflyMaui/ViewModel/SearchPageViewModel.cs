using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SeagullflyMaui.View;

namespace SeagullflyMaui.ViewModel;
public partial class SearchPageViewModel : BaseViewModel
{
	[ObservableProperty]
	string data;

    [ObservableProperty]
    string buttonName;

    public SearchPageViewModel()
	{
		Title = "Searching page!";
        ButtonName = "Here will be scraped content!";
	}

    [RelayCommand]
    async Task SearchFlights()
    {
        await Shell.Current.GoToAsync(nameof(FlightsResultsPage));
    }
}
