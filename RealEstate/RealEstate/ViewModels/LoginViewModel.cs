using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace RealEstate.ViewModels
{
    public class LoginViewModel
    {
        public LoginViewModel()
        {
            if (Preferences.ContainsKey(PreferencesKeys.IsUserLoggedIn)
                && Preferences.Get(PreferencesKeys.IsUserLoggedIn, false))
            {
                Shell.Current.GoToAsync("//ListPage");
            }
        }

        public ICommand LoginCommand => new Command(async () =>
        {
            Preferences.Set(PreferencesKeys.IsUserLoggedIn, true);
            await Shell.Current.GoToAsync("//ListPage");
        });
    }
}
