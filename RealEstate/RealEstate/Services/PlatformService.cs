using System;
using System.Threading.Tasks;
using RealEstate.Interfaces;
using Xamarin.Essentials;

namespace RealEstate.Services
{
    public class PlatformService : IPlatformService
    {
        public bool PreferencesContainsKey(string key)
        {
            return Preferences.ContainsKey(key);
        }

        public bool PreferencesGetBool(string key, bool defaultValue)
        {
            return Preferences.Get(key, defaultValue);
        }

        public DateTime PreferencesGetDate(string key, DateTime defaultValue)
        {
            return Preferences.Get(key, defaultValue);
        }

        public void PreferencesSetBool(string key, bool value)
        {
            Preferences.Set(key, value);
        }

        public void PreferencesSetDate(string key, DateTime value)
        {
            Preferences.Set(key, value);
        }

        public async Task<string> SecureGetAsync(string key)
        {
            return await SecureStorage.GetAsync(key);
        }

        public async Task SecureSetAsync(string key, string value)
        {
            await SecureStorage.SetAsync(key, value);
        }
    }
}
