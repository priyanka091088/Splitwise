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
        Task<IEnumerable<UserDTO>> GetUser();
        public void AddUser(ApplicationUser user);
        public void UpdateProfile(ApplicationUser user);
        Task<UserDTO> Login(UserDTO user);
        Task<UserDTO> GetUserById(string userId);
        public bool UserExists(string userId);
    }
}
