using System;
using System.Threading.Tasks;

namespace RealEstate.Interfaces
{
    public interface INavigationService
    {
        Task NavigateToAsync(string route);
    }
}
