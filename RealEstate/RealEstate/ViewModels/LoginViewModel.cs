using System;
using System.Windows.Input;
using RealEstate.Interfaces;
using RealEstate.Models;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace RealEstate.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private IEstatesServices _estatesService;
        private IPlatformService _platformService;
        private INavigationService _navigationService;

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

        public LoginViewModel(IEstatesServices estatesServices,
            IPlatformService platformService,
            INavigationService navigationService)
        {
            _estatesService = estatesServices;
            _platformService = platformService;
            _navigationService = navigationService;

            if (_platformService.PreferencesContainsKey(PreferencesKeys.IsUserLoggedIn)
                && _platformService.PreferencesGetBool(PreferencesKeys.IsUserLoggedIn, false))
            {
                _navigationService.NavigateToAsync("//ListPage");
            }
        }

        public ICommand LoginCommand => new Command(async () =>
        {
            var user = await _estatesService.Login(new AuthenticateModel { Username = Username, Password = Password });

            if (user != null)
            {
                await _platformService.SecureSetAsync(PreferencesKeys.UsernameKey, user.Username);
                await _platformService.SecureSetAsync(PreferencesKeys.PasswordKey, Password);

                _platformService.PreferencesSetBool(PreferencesKeys.IsUserLoggedIn, true);
                await _navigationService.NavigateToAsync("//ListPage");
            }
        });
    }
}
