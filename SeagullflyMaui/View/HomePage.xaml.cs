﻿using SeagullflyMaui.ViewModel;

namespace SeagullflyMaui.View;

public partial class HomePage : ContentPage
{
    public HomePage(HomePageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}

