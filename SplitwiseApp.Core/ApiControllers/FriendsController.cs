using Microsoft.AspNetCore.Mvc;
using SplitwiseApp.Repository.DTOs;
using SplitwiseApp.Repository.Friends;
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
        public FriendsController(IFriends friends)
        {
            _friends = friends;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<FriendsDTO>>> GetFriends(string id)
        {

            IEnumerable<FriendsDTO> friendDtos = await _friends.GetFriends(id);
            return Ok(friendDtos);
        }

        [HttpPost]
        public async Task<ActionResult<FriendsDTO>> AddAFriend(FriendsDTO friends)
        {

            FriendsDTO addFriend = await _friends.AddAFriend(friends);
            return Ok(addFriend);
        }

        [HttpPut]
        public async Task<ActionResult<FriendsDTO>> UpdateFriend(FriendsDTO friends)
        {

            FriendsDTO updateFriend = await _friends.UpdateAFriend(friends);
            return Ok(updateFriend);
        }

        [HttpDelete]
        public async Task<ActionResult<FriendsDTO>> DeleteFriend(int id)
        {

            FriendsDTO deleteFriend = await _friends.DeleteAFriend(id);
            return Ok(deleteFriend);
        }
    }
}
