using SplitwiseApp.Repository.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SplitwiseApp.DomainModels.Models;

namespace SplitwiseApp.Repository.Friend
{
    public interface IFriends
    {
        Task<IEnumerable<FriendsDTO>> GetFriends(string userId);
        public void AddAFriend(Friends friends);
        public void UpdateAFriend(Friends friends);
        public void DeleteAFriend(int id);
        public bool FriendExist(int friendId);
    }
}
