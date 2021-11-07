using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealEstate.Api.Interfaces;
using RealEstate.Api.Models;

namespace RealEstate.Api.Services
{
    public class EstatesRepository : IRepository<Estate>
    {
        public async Task<List<Estate>> GetAll()
        {
            return await Task.FromResult(StaticDb.Estates);
        }

        public async Task<Estate> GetById(int id)
        {
            return await Task.FromResult(StaticDb.Estates.FirstOrDefault(x => x.Id == id));
        }

        public Task<Estate> Insert(Estate entity)
        {
            StaticDb.Estates.Add(entity);
            return Task.FromResult(entity);
        }

        public async Task<Estate> Update(Estate entity)
        {
            var estateToUpdate = StaticDb.Estates.FirstOrDefault(x => x.Id == entity.Id);

            estateToUpdate.EstateName = entity.EstateName;
            estateToUpdate.ContactPersonName = entity.ContactPersonName;
            estateToUpdate.ContactPersonPhone = entity.ContactPersonPhone;
            estateToUpdate.ContactPersonEmail = entity.ContactPersonEmail;
            estateToUpdate.Latitude = entity.Latitude;
            estateToUpdate.Longitude = entity.Longitude;
            estateToUpdate.Address = entity.Address;
            estateToUpdate.PhotoUrl = entity.PhotoUrl;
            estateToUpdate.Available = entity.Available;

            return await Task.FromResult(estateToUpdate);
        }

        public Task<bool> Delete(int id)
        {
            var estateToDelete = StaticDb.Estates.FirstOrDefault(x => x.Id == id);

            if (estateToDelete != null)
            {
                StaticDb.Estates.Remove(estateToDelete);
                return Task.FromResult(true);
            }

            return Task.FromResult(false);
        }
    }
}
