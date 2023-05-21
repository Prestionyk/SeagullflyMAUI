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
        var airport = (Airport)e.CurrentSelection[0];
        _viewModel.QueryLoaded = false;
        _viewModel.BtnSaveEnabled = true;
        _viewModel.From = airport?.IATACode ?? string.Empty;
    }

    private void SfAutocomplete_SelectionChangedTo(object sender, Syncfusion.Maui.Inputs.SelectionChangedEventArgs e)
    {
        var airport = (Airport)e.CurrentSelection[0];
        _viewModel.QueryLoaded = false;
        _viewModel.BtnSaveEnabled = true;
        _viewModel.To = airport?.IATACode ?? string.Empty;
    }

    private void QueryLoaded(object sender, EventArgs e)
    {
        _viewModel.QueryLoaded = true;
        _viewModel.BtnSaveEnabled = false;
        _viewModel.SelectedQueryId = (((Picker)sender).SelectedItem as SearchQueryDto).Id;
    }

    private void QueryPropertiesChanged(object sender, EventArgs e)
    {
        _viewModel.QueryLoaded = false;
        _viewModel.BtnSaveEnabled = true;
    }
}

