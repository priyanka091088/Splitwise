using Microsoft.AspNetCore.Mvc;
using SplitwiseApp.DomainModels.Models;
using SplitwiseApp.Repository.DTOs;
using SplitwiseApp.Repository.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitwiseApp.Core.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController: ControllerBase
    {
        private readonly IUser _user;
        public UserController(IUser user)
        {
            _user = user;
        }

        [HttpGet]
        public IEnumerable<UserDTO> GetUsers()
        {
            
            return _user.GetUsers();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUser(string id)
        {
            if (_user.UserExists(id))
            {
                ApplicationUser user = await _user.GetUserById(id);
                return Ok(user);
            }
            return NotFound();
        }

        [HttpPost]
        [Route("signup")]
        public async Task<IActionResult> SignUp(signUpDTO user)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

           var u= await _user.AddUser(user);
            return Ok(u);
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
