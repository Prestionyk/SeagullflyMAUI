using CommunityToolkit.Maui;
using Seagullfly.Services;
using SeagullflyMaui.Interfaces;
using SeagullflyMaui.Services;
using SeagullflyMaui.Storage;
using SeagullflyMaui.View;
using SeagullflyMaui.ViewModel;
using Syncfusion.Maui.Core.Hosting;

namespace SeagullflyMaui;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureSyncfusionCore()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });
        builder.RegisterDependencyInjection();

        return builder.Build();
    }

    public static MauiAppBuilder RegisterDependencyInjection(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<HomePageViewModel>();
        builder.Services.AddSingleton<HomePage>();

        builder.Services.AddSingleton<SearchPageViewModel>();
        builder.Services.AddSingleton<SearchPage>();

        builder.Services.AddTransient<ContactPageViewModel>();
        builder.Services.AddTransient<ContactPage>();

        builder.Services.AddTransient<FlightsResultsViewModel>();
        builder.Services.AddTransient<FlightsResultsPage>();

        builder.Services.AddTransient<FlightDetailsViewModel>();
        builder.Services.AddTransient<FlightDetailsPage>();

        builder.Services.AddSingleton<ISeagullflyDatabase, SeagullflyDatabase>();

        builder.Services.AddSingleton<IEmailService, EmailService>();
        builder.Services.AddSingleton<ISearchQueryService, SearchQueryService>();
        builder.Services.AddSingleton<IAiportsService, AiportsService>();
        builder.Services.AddSingleton<IFlightOffersService, FlightOffersService>();
        builder.Services.AddSingleton<IWeatherService, WeatherService>();

        return builder;
    }
}
