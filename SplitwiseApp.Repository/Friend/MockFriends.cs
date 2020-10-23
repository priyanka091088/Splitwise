using SplitwiseApp.Repository.DTOs;
using SplitwiseApp.DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SplitwiseApp.Repository.Friend
{
    public class MockFriends : IFriends
    {
        public void AddAFriend(Friends friends)
        {
            throw new NotImplementedException();
        }

        public void DeleteAFriend(int id)
        {
            throw new NotImplementedException();
        }

        public bool FriendExist(int friendId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<FriendsDTO>> GetFriends(string userId)
        {
            throw new NotImplementedException();
        }

        public void UpdateAFriend(Friends friends)
        {
            throw new NotImplementedException();
        }
    }
}
