using Microsoft.AspNetCore.Identity;
using SplitwiseApp.DomainModels.Models;
using SplitwiseApp.Repository.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitwiseApp.Repository.User
{
    public class MockUser : IUser
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public MockUser(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public void AddUser(ApplicationUser user)
        {
            var password = user.Name + "@123";
            _userManager.CreateAsync(user, password);
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserDTO>> GetUser()
        {
            
            throw new NotImplementedException();
        }

        public async Task<UserDTO> GetUserById(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            throw new NotImplementedException();
        }

        public Task<UserDTO> Login(UserDTO user)
        {
            throw new NotImplementedException();
        }

        public void UpdateProfile(ApplicationUser user)
        {
            var users = _userManager.FindByIdAsync(user.Id);
            _userManager.UpdateAsync(user);
            throw new NotImplementedException();
        }

        public bool UserExists(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
