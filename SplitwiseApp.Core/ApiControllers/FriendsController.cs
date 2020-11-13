using Microsoft.AspNetCore.Mvc;
using SplitwiseApp.DomainModels.Models;
using SplitwiseApp.Repository.DTOs;
using SplitwiseApp.Repository.Friend;
using SplitwiseApp.Repository.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SplitwiseApp.Core.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendsController : ControllerBase
    {
        #region private variables

        private readonly IFriends _friends;
        private readonly IUser _user;
        #endregion

        #region constructor
        public FriendsController(IFriends friends,IUser user)
        {
            _friends = friends;
            _user = user;
        }
        #endregion

        #region API controller methods
        [HttpGet("getByUserId/{id}")]
        public ActionResult<IEnumerable<FriendsDTO>> GetFriends(string id)
        {
            if (_user.UserExists(id))
            {
                IEnumerable<FriendsDTO> friendDtos =  _friends.GetFriends(id);
                return Ok(friendDtos);
            }
            return NotFound();
        }


        [HttpGet("getBalance/{userId}")]
        public ActionResult<IEnumerable<FriendsDTO>> GetFriendsBalance(string userId)
        {
            if (_user.UserExists(userId))
            {
                IEnumerable<FriendsDTO> friendDtos = _friends.GetFriendBalance(userId);
                return Ok(friendDtos);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult AddAFriend(Friends friends)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var count = _friends.AddAFriend(friends);

            if (count == 0)
            {
                return NotFound();

            }
            else
                return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateFriend(Friends friends,int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }


            if (!_friends.FriendExist(id) && !(friends.Id==id))
            {
                return BadRequest();
            }

            var count = _friends.UpdateAFriend(friends);
            if (count == 0)
            {
                return NotFound();
            }
            else {
                return Ok();
            }
            
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFriend(int id)
        {
            if (!_friends.FriendExist(id))
            {
              
                return BadRequest();
            }
            var count = _friends.DeleteAFriend(id);

            if (count == 0)
            {
                return NotFound();

            }
            else
                return Ok();
            
            
        }
        #endregion
    }
}
