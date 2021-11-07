using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstate.Api.Interfaces
{
    public interface IRepository<T>
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> Insert(T entity);
        Task<T> Update(T entity);
        Task<bool> Delete(int id);
    }
}
