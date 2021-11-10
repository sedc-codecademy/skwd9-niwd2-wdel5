using System.Collections.Generic;
using System.Threading.Tasks;
using RealEstate.Models;

namespace RealEstate.Services
{
    public class EstatesService
    {
        private RestClientService _restClinetService;

        public EstatesService()
        {
            _restClinetService = new RestClientService();
        }

        public async Task<User> Login(AuthenticateModel authenticateModel)
        {
            return await _restClinetService.PostAsync<User>("estates/authenticate", authenticateModel);
        }

        public async Task<List<Estate>> GetAllEastates()
        {
            return await _restClinetService.GetAsync<List<Estate>>("estates");
        }

        public async Task<Estate> GetEstate(long id)
        {
            return await _restClinetService.GetAsync<Estate>($"estates/{id}");
        }

        public async Task<Estate> CreateEstate(Estate estate)
        {
            return await _restClinetService.PostAsync<Estate>("estates/create", estate);
        }

        public async Task<Estate> UpdateEstate(Estate estate)
        {
            return await _restClinetService.PatchAsync<Estate>("estates/update", estate);
        }

        public async Task<bool> DeleteEstate(long id)
        {
            return await _restClinetService.DeleteAsync<bool>($"estates/delete/{id}");
        }
    }
}
