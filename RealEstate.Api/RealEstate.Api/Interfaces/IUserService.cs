using System.Threading.Tasks;
using RealEstate.Api.Models;

namespace RealEstate.Api.Interfaces
{
    public interface IUserService
    {
        Task<User> Authenticate(string username, string password);
    }
}
