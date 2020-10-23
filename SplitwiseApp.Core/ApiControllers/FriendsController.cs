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
        private readonly IFriends _friends;
        private readonly IUser _user;
        public FriendsController(IFriends friends,IUser user)
        {
            _friends = friends;
            _user = user;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<FriendsDTO>>> GetFriends(string id)
        {
            if (_user.UserExists(id))
            {
                IEnumerable<FriendsDTO> friendDtos = await _friends.GetFriends(id);
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
            _friends.AddAFriend(friends);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateFriend(Friends friends)
        {
            if (_friends.FriendExist(friends.friendId))
            {
                _friends.UpdateAFriend(friends);
                return Ok();
            }
            return NotFound();
        }

        [HttpDelete]
        public IActionResult DeleteFriend(int id)
        {
            if (_friends.FriendExist(id))
            {
                _friends.DeleteAFriend(id);
                return Ok();
            }
            return NotFound();
        }
    }
}
