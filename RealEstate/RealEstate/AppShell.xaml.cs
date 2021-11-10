using RealEstate.Views;
using Xamarin.Forms;

namespace RealEstate
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(DetailsPage), typeof(DetailsPage));
            Routing.RegisterRoute(nameof(UpsertPage), typeof(UpsertPage));
        }
    }
}
