using SplitwiseApp.Repository.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SplitwiseApp.Repository.Friends
{
    public class MockFriends : IFriends
    {
        public Task<FriendsDTO> AddAFriend(FriendsDTO friends)
        {
            throw new NotImplementedException();
        }

        public Task<FriendsDTO> DeleteAFriend(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<FriendsDTO>> GetFriends(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<FriendsDTO> UpdateAFriend(FriendsDTO friends)
        {
            throw new NotImplementedException();
        }
    }
}
