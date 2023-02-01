using SeagullflyMaui.ViewModel;

namespace SeagullflyMaui.View;

public partial class FlightDetailsPage : ContentPage
{
	public FlightDetailsPage(FlightDetailsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}