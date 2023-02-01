using SeagullflyMaui.View;

namespace SeagullflyMaui;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(FlightsResultsPage), typeof(FlightsResultsPage));
        Routing.RegisterRoute(nameof(FlightDetailsPage), typeof(FlightDetailsPage));
    }
}
