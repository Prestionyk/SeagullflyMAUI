using CommunityToolkit.Mvvm.Input;
using SeagullflyMaui.MockData;
using SeagullflyMaui.Model;

namespace SeagullflyMaui.ViewModel;
public partial class HomePageViewModel : BaseViewModel
{
    public List<DayOffer> OffersOfTheDay { get; set; }

    public HomePageViewModel()
	{
        OffersOfTheDay = RandomData.GetOffersOfTheDay();
	}

    [RelayCommand]
    void GoToUrl(string url)
    {
        Browser.Default.OpenAsync(url, BrowserLaunchMode.SystemPreferred);
    }
}
