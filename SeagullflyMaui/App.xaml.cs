using Syncfusion.Licensing;

namespace SeagullflyMaui;

public partial class App : Application
{
    public App()
    {
        SyncfusionLicenseProvider.RegisterLicense("MjA4Njk0OUAzMjMxMmUzMjJlMzNoZEtSQTEwQ2JDQVh1S3NRZHBFUHFWZThRRzF2ZHVIbU14VE81TndacVlJPQ==");

        InitializeComponent();

        MainPage = new AppShell();
    }
}
