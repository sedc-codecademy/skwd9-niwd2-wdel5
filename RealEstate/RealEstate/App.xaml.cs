using System;
using RealEstate.Views;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RealEstate
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var loggedIn = Preferences.Get(PreferencesKeys.IsUserLoggedIn, false);

            if (loggedIn)
            {
                MainPage = new NavigationPage(new ListPage());
            }
            else
            {
                MainPage = new LoginPage();
            }
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
