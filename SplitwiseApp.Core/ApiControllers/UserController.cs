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
        #region private variables

        private readonly IUser _user;
        #endregion

        #region constructor
        public UserController(IUser user)
        {
            _user = user;
        }
        #endregion

        #region API controller methods

        [HttpGet]
        public IEnumerable<UserDTO> GetUsers()
        {
            return _user.GetUsers();
        }
        [HttpGet("getById/{id}")]
        public ActionResult<UserDTO> GetUser(string id)
        {
            if (_user.UserExists(id))
            {
                return _user.GetUserById(id);
            }
            return NotFound();
        }

        [HttpGet("getByEmail/{email}")]
        public async Task<ActionResult<UserDTO>> GetUserByEmail(string email)
        {
            
                return await _user.GetUserByEmailId(email);
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
        public async Task<ActionResult<string>> Login(LoginDTO user)
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

        [HttpPut("{userId}")]
        public async Task<IActionResult> Profile(UserDTO user,string userId)
        {
            if (userId != user.Id)
            {
                return BadRequest();
            }
            var users = await _user.UpdateProfile(user);
            if (users!=null)
            {
                
                return Ok(user);
            }
            return NotFound();
        }

        [HttpPut("getBalance/{Id}")]
        public async Task<IActionResult> GetUserBalance(string Id)
        {
            var users= await _user.GetBalanceByUserId(Id);
            if (users != null)
            {

                return Ok(users);
            }
            return NotFound();
        }
        #endregion
    }
}
