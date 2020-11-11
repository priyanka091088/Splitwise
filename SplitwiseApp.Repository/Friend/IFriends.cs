using SplitwiseApp.Repository.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SplitwiseApp.DomainModels.Models;
using Microsoft.AspNetCore.Mvc;

namespace SplitwiseApp.Repository.Friend
{
    public interface IFriends
    {
        IEnumerable<FriendsDTO> GetFriends(string userId);
        public IEnumerable<FriendsDTO> GetFriendBalance(string userId);
        public int AddAFriend(Friends friends);
        public int UpdateAFriend(Friends friends);
        public int DeleteAFriend(int id);
        public bool FriendExist(int friendId);
       
    }
}
