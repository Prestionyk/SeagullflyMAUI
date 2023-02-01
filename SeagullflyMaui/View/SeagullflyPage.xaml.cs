using SeagullflyMaui.ViewModel;

namespace SeagullflyMaui.View;

public partial class SeagullflyPage : ContentPage
{
    public SeagullflyPage(SeagullflyPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}

