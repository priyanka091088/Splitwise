using Microsoft.AspNetCore.Identity;
using SplitwiseApp.DomainModels.Models;
using SplitwiseApp.Repository.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SplitwiseApp.Repository.User
{
    public interface IUser
    {
        IEnumerable<UserDTO> GetUsers();
        public Task<IdentityResult> AddUser(signUpDTO user);
        public Task UpdateProfile(ApplicationUser user);
        Task<UserDTO> Login(UserDTO user);
        Task<ApplicationUser> GetUserById(string userId);
        public bool UserExists(string userId);
    }
}
