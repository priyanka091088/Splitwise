using SplitwiseApp.Repository.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SplitwiseApp.Repository.User
{
    public class MockUser : IUser
    {
        public Task<UserDTO> AddUser(UserDTO user)
        {
            throw new NotImplementedException();
        }

        public Task<UserDTO> Login(UserDTO user)
        {
            throw new NotImplementedException();
        }

        public Task<UserDTO> UpdateProfile(UserDTO user)
        {
            throw new NotImplementedException();
        }
    }
}
