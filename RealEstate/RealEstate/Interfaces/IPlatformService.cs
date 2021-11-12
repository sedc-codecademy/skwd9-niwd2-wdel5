using System;
using System.Threading.Tasks;

namespace RealEstate.Interfaces
{
    public interface IPlatformService
    {
        Task SecureSetAsync(string key, string value);

        Task<string> SecureGetAsync(string key);

        void PreferencesSetBool(string key, bool value);

        void PreferencesSetDate(string key, DateTime value);

        bool PreferencesGetBool(string key, bool defaultValue);

        DateTime PreferencesGetDate(string key, DateTime defaultValue);

        bool PreferencesContainsKey(string key);
    }
}
