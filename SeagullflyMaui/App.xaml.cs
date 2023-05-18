using Syncfusion.Licensing;

namespace SeagullflyMaui;

public partial class App : Application
{
    public App()
    {
        SyncfusionLicenseProvider.RegisterLicense(Config.GetInstance().SyncfusionLicenseKey);

        InitializeComponent();

        MainPage = new AppShell();
    }
}
