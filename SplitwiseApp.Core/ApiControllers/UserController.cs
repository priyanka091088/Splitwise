using Microsoft.AspNetCore.Mvc;
using SplitwiseApp.Repository.DTOs;
using SplitwiseApp.Repository.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SplitwiseApp.Core.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    class UserController: ControllerBase
    {
        private readonly IUser _user;
        public UserController(IUser user)
        {
            _user = user;
        }

        [HttpPost]
        [Route("signup")]
        public async Task<ActionResult<UserDTO>> SignUp(UserDTO user)
        {

            UserDTO register = await _user.AddUser(user);
            return Ok(register);
        }
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<UserDTO>> Login(UserDTO friends)
        {

            UserDTO login = await _user.Login(friends);
            return Ok(login);
        }

        [HttpPut]
        public async Task<ActionResult<UserDTO>> Profile(UserDTO user)
        {

            UserDTO updateProfile = await _user.UpdateProfile(user);
            return Ok(updateProfile);
        }
    }
}
