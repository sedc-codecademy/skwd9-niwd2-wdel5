using System;
using System.Threading.Tasks;

namespace RealEstate.Interfaces
{
    public interface IRestClientService
    {
        Task<T> GetAsync<T>(string route);

        Task<T> PostAsync<T>(string route, object body);

        Task<T> PatchAsync<T>(string route, object body);

        Task<T> DeleteAsync<T>(string route);
    }
}
