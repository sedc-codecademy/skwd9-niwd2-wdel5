using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace RealEstate.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        void Button_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new ListPage());
        }
    }
}
