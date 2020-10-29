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
        public ActionResult<FriendsDTO> GetFriends(string id)
        {
            if (_user.UserExists(id))
            {
                var friendDtos =  _friends.GetFriends(id);
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
    }
}
