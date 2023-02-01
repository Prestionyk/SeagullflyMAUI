using SeagullflyMaui.ViewModel;

namespace SeagullflyMaui.View;

public partial class SearchPage : ContentPage
{
    public SearchPage(SearchPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}

