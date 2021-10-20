using System;
using RealEstate.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RealEstate
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new DetailsPage();
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
