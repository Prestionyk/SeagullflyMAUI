using SeagullflyMaui.ViewModel;

namespace SeagullflyMaui.View;

public partial class ContactPage : ContentPage
{
    public ContactPage(ContactPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}

