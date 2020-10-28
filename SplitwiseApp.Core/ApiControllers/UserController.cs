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
        public ActionResult<UserDTO> GetUser(string id)
        {
            if (_user.UserExists(id))
            {
                return _user.GetUserById(id);
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
        public async Task<IActionResult> Login(LoginDTO user)
        {
            var login = await _user.Login(user);
            if (login!=null)
            {
                return Ok(login);
            }
            else
            {
                return BadRequest();
            }
            
        }

        [HttpPut]
        public async Task<IActionResult> Profile(UserDTO user)
        {
            var users= await _user.UpdateProfile(user);
            if (users!=null)
            {
                
                return Ok(user);
            }
            return NotFound();
        }
    }
}
