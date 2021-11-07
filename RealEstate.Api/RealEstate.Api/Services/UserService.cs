using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealEstate.Api.Interfaces;
using RealEstate.Api.Models;

namespace RealEstate.Api.Services
{
    public class UserService : IUserService
    {
        public UserService()
        {
        }

        private List<User> _users = new List<User>()
        {
            new User
            {
                Id = 1,
                FirstName = "Test",
                LastName = "User",
                Username = "User",
                Password = "Test"
            }
        };

        public async Task<User> Authenticate(string username, string password)
        {
            var user = _users.FirstOrDefault(x => x.Username == username && x.Password == password);

            return await Task.FromResult(user);
        }
    }
}
