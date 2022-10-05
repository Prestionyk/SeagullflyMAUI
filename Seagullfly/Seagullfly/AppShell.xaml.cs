using Seagullfly.Views;
using Xamarin.Forms;

namespace Seagullfly
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(SeagullflyPage), typeof(SeagullflyPage));
            Routing.RegisterRoute(nameof(FeadbackPage), typeof(FeadbackPage));
        }
    }
}
