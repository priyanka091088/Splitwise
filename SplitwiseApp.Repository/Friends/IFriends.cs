using SplitwiseApp.Repository.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SplitwiseApp.Repository.Friends
{
    public interface IFriends
    {
        Task<IEnumerable<FriendsDTO>> GetFriends(string userId);
        Task<FriendsDTO> AddAFriend(FriendsDTO friends);
        Task<FriendsDTO> UpdateAFriend(FriendsDTO friends);
        Task<FriendsDTO> DeleteAFriend(int id);
    }
}
