using CommunityToolkit.Mvvm.Input;
using SeagullflyMaui.Model;

namespace SeagullflyMaui.ViewModel;
public partial class HomePageViewModel : BaseViewModel
{
    public List<DayOffer> OffersOfTheDay { get; set; }

    public HomePageViewModel()
	{
        OffersOfTheDay = new List<DayOffer>()
        {
            new DayOffer
            {
                Price = "10 PLN",
                Description = "Tygodniowe all inclusive w 5* hotelu w Turcji od 1256 PLN",
                Shortcut = "Turcja all inclusive z 5 miast"
            },
            new DayOffer
            {
                Price = "10 PLN",
                Description = "Tygodniowe all inclusive w 5* hotelu w Turcji od 1256 PLN",
                Shortcut = "Turcja all inclusive z 5 miast"
            }
            ,
            new DayOffer
            {
                Price = "10 PLN",
                Description = "Tygodniowe all inclusive w 5* hotelu w Turcji od 1256 PLN",
                Shortcut = "Turcja all inclusive z 5 miast"
            }
            ,
            new DayOffer
            {
                Price = "10 PLN",
                Description = "Tygodniowe all inclusive w 5* hotelu w Turcji od 1256 PLN",
                Shortcut = "Turcja all inclusive z 5 miast"
            }
            ,
            new DayOffer
            {
                Price = "10 PLN",
                Description = "Tygodniowe all inclusive w 5* hotelu w Turcji od 1256 PLN",
                Shortcut = "Turcja all inclusive z 5 miast"
            },
            new DayOffer
            {
                Price = "10 PLN",
                Description = "Tygodniowe all inclusive w 5* hotelu w Turcji od 1256 PLN",
                Shortcut = "Turcja all inclusive z 5 miast"
            },
            new DayOffer
            {
                Price = "10 PLN",
                Description = "Tygodniowe all inclusive w 5* hotelu w Turcji od 1256 PLN",
                Shortcut = "Turcja all inclusive z 5 miast"
            },
            new DayOffer
            {
                Price = "10 PLN",
                Description = "Tygodniowe all inclusive w 5* hotelu w Turcji od 1256 PLN",
                Shortcut = "Turcja all inclusive z 5 miast"
            }
        };
	}

    [RelayCommand]
    public void GoToUrl(string url)
    {
        Browser.Default.OpenAsync(url, BrowserLaunchMode.SystemPreferred);
    }
}
