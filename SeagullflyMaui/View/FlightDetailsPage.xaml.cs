using SeagullflyMaui.ViewModel;

namespace SeagullflyMaui.View;

public partial class FlightDetailsPage : ContentPage
{
	private readonly FlightDetailsViewModel viewModel;
	public FlightDetailsPage(FlightDetailsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
		this.viewModel = viewModel;
	}

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
		viewModel.LoadDetails();
    }
}