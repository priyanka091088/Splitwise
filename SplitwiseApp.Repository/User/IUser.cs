using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
        public Task<IdentityResult> UpdateProfile(UserDTO user);
        Task<string> Login(LoginDTO user);
        ActionResult<UserDTO> GetUserById(string userId);
        Task<ActionResult<UserDTO>> GetUserByEmailId(string email);
        public bool UserExists(string userId);
    }
}
