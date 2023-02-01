using Seagullfly.Services;
using SeagullflyMaui.Interfaces;
using SeagullflyMaui.View;
using SeagullflyMaui.ViewModel;

namespace SeagullflyMaui;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });
        builder.Services.AddSingleton<IEmailService, EmailService>();

        builder.Services.AddSingleton<HomePageViewModel>();
        builder.Services.AddSingleton<HomePage>();

        builder.Services.AddSingleton<SearchPageViewModel>();
        builder.Services.AddSingleton<SearchPage>();

        builder.Services.AddSingleton<ContactPageViewModel>();
        builder.Services.AddSingleton<ContactPage>();

        return builder.Build();
    }
}
