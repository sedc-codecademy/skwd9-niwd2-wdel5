using System;
using System.Windows.Input;
using RealEstate.Models;
using RealEstate.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace RealEstate.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private EstatesService _estatesService;

        private string _username;
        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public LoginViewModel()
        {
            if (Preferences.ContainsKey(PreferencesKeys.IsUserLoggedIn)
                && Preferences.Get(PreferencesKeys.IsUserLoggedIn, false))
            {
                Shell.Current.GoToAsync("//ListPage");
            }

            _estatesService = new EstatesService();
        }

        public ICommand LoginCommand => new Command(async () =>
        {
            var user = await _estatesService.Login(new AuthenticateModel { Username = Username, Password = Password });

            if (user != null)
            {
                await SecureStorage.SetAsync(PreferencesKeys.UsernameKey, user.Username);
                await SecureStorage.SetAsync(PreferencesKeys.PasswordKey, Password);

                Preferences.Set(PreferencesKeys.IsUserLoggedIn, true);
                await Shell.Current.GoToAsync("//ListPage");
            }
        });
    }
}
