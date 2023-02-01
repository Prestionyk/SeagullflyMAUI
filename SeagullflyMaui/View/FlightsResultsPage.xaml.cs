using SeagullflyMaui.ViewModel;

namespace SeagullflyMaui.View;

public partial class FlightsResultsPage : ContentPage
{
	public FlightsResultsPage(FlightsResultsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}