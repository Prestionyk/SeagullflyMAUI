﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace SeagullflyMaui.ViewModel;
public partial class SeagullflyPageViewModel : BaseViewModel
{
	[ObservableProperty]
	string data;

    [ObservableProperty]
    string buttonName;

    public SeagullflyPageViewModel()
	{
		title = "Scraping page!";
        buttonName = "Here will be scraped content!";
	}

    [RelayCommand]
    async Task ScrapData()
    {
        //var requester = new HttpService();
        //var html = await requester.GetHtmlFromUrl("https://www.esky.pl/flights/select/roundtrip/ap/wro/ap/waw?departureDate=2022-09-26&returnDate=2022-09-27&pa=1&py=0&pc=0&pi=0&sc=economy");
        //Data = html;
        //ButtonName = "Data scrapped!";
        data = "Scraped!";
    }
}