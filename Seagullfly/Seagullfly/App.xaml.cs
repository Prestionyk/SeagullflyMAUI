using Seagullfly.Interfaces;
using Seagullfly.Services;
using Xamarin.Forms;

namespace Seagullfly
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<IEmailService, EmailService>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
