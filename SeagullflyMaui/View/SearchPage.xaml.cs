using SeagullflyMaui.DTOs;
using SeagullflyMaui.Model;
using SeagullflyMaui.ViewModel;

namespace SeagullflyMaui.View;

public partial class SearchPage : ContentPage
{
    readonly SearchPageViewModel _viewModel;

    public SearchPage(SearchPageViewModel viewModel)
    {
        _viewModel = viewModel;
        InitializeComponent();
        BindingContext = viewModel;
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        _viewModel.InitAsync();
    }

    private void SfAutocomplete_SelectionChangedFrom(object sender, Syncfusion.Maui.Inputs.SelectionChangedEventArgs e)
    {
        _viewModel.RemoveQueryIfDifferent();
    }

    private void SfAutocomplete_SelectionChangedTo(object sender, Syncfusion.Maui.Inputs.SelectionChangedEventArgs e)
    {
        _viewModel.RemoveQueryIfDifferent();
    }

    private void QueryLoaded(object sender, EventArgs e)
    {
        if (((Picker)sender).SelectedItem is SearchQueryDto loadedQuery)
        {
            _viewModel.QueryIsLoading = true;
            _viewModel.From = _viewModel.Airports.Where(a => a.IATACode == loadedQuery.From).FirstOrDefault();
            _viewModel.To = _viewModel.Airports.Where(a => a.IATACode == loadedQuery.To).FirstOrDefault();
            _viewModel.Arrival = loadedQuery.Arrival;
            _viewModel.Departure = loadedQuery.Departure;

            _viewModel.SelectedFlightTypeIndex = _viewModel.FlightTypes.IndexOf(loadedQuery.FlightType);
            _viewModel.AdultCount = loadedQuery.AdultCount;
            _viewModel.ChildrenCount = loadedQuery.ChildrenCount;
            _viewModel.YouthCount = loadedQuery.YouthCount;
            _viewModel.InfantCount = loadedQuery.InfantCount;

            _viewModel.QueryLoaded = true;
            _viewModel.BtnSaveEnabled = false;
            _viewModel.QueryIsLoading = false;
        }
    }

    private void QueryPropertiesChanged(object sender, EventArgs e)
    {
        _viewModel.RemoveQueryIfDifferent();
    }
}

