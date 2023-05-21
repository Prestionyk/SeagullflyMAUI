using SeagullflyMaui.ViewModel;

namespace SeagullflyMaui.View;

public partial class FlightsResultsPage : ContentPage
{
	private readonly FlightsResultsViewModel viewModel;
	public FlightsResultsPage(FlightsResultsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
		this.viewModel = viewModel;
	}

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        viewModel.LoadFlightOffers();
    }
}