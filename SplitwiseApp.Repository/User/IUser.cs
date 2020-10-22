using SplitwiseApp.Repository.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SplitwiseApp.Repository.User
{
    public interface IUser
    {
        Task<UserDTO> AddUser(UserDTO user);
        Task<UserDTO> UpdateProfile(UserDTO user);
        Task<UserDTO> Login(UserDTO user);
        Task<UserDTO> GetUserById(string userId);
    }
}
