using Microsoft.AspNetCore.Mvc;
using SplitwiseApp.DomainModels.Models;
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

        [HttpGet]
        public async Task<ActionResult<UserDTO>> GetUser(string id)
        {
            if (_user.UserExists(id))
            {
                UserDTO user = await _user.GetUserById(id);
                return Ok(user);
            }
            return NotFound();
        }

        [HttpPost]
        [Route("signup")]
        public IActionResult SignUp(ApplicationUser user)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            _user.AddUser(user);
            return Ok();
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login(UserDTO user)
        {
            if (!ModelState.IsValid)
            {

                UserDTO login = await _user.Login(user);
                return Ok(login);
            }
            return BadRequest();
        }

        [HttpPut]
        public IActionResult Profile(ApplicationUser user)
        {
            if (_user.UserExists(user.Id))
            {
                _user.UpdateProfile(user);
                return Ok();
            }
            return NotFound();
        }
    }
}
