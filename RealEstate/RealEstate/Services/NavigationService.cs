using System;
using System.Threading.Tasks;
using RealEstate.Interfaces;
using Xamarin.Forms;

namespace RealEstate.Services
{
    public class NavigationService : INavigationService
    {
        public async Task NavigateToAsync(string route)
        {
            await Shell.Current.GoToAsync(route);
        }
    }
}
