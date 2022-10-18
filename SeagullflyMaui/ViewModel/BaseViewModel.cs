using CommunityToolkit.Mvvm.ComponentModel;

namespace SeagullflyMaui.ViewModel;
public partial class BaseViewModel : ObservableObject
{
    [ObservableProperty]
    protected string title;
}
