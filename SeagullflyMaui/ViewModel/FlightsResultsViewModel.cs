﻿using CommunityToolkit.Mvvm.Input;
using SeagullflyMaui.View;

namespace SeagullflyMaui.ViewModel;
public partial class FlightsResultsViewModel : BaseViewModel
{

	public FlightsResultsViewModel()
	{
        Title = "SEAGULLFLY";
    }

    [RelayCommand]
    async Task FlightDetails()
    {
        await Shell.Current.GoToAsync(nameof(FlightDetailsPage));
    }
}