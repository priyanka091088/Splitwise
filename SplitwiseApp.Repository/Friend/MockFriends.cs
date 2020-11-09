using SplitwiseApp.Repository.DTOs;
using SplitwiseApp.DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
namespace SplitwiseApp.Repository.Friend
{
    public class MockFriends : IFriends
    {
        #region private variables
        private readonly AppDbContext _context;
       
        #endregion

        #region constructor
        public MockFriends()
        {

        }
        public MockFriends(AppDbContext context)
        {
            _context = context;
            
        }

        #endregion

        #region public methods
        public int AddAFriend(Friends friends)
        {
            List<Friends> search = new List<Friends>();

           //checks if the user is already a friend or not
            var res=_context.friends.Where(c=>c.creatorId==friends.creatorId && c.friendId==friends.friendId 
            || c.friendId==friends.creatorId && c.creatorId==friends.friendId);

            search.AddRange(res);
            //will not add if the user is already a friend
            if (search.Count != 0)
            {
                return 0;
            }
            
            _context.friends.Add(friends);

            Friends friend = new Friends();
            var id = friends.creatorId;
            friend.creatorId = friends.friendId;
            friend.friendId=id;
            _context.friends.Add(friend);
            
            var result = _context.SaveChanges();
            return result;
            
        }

        public int DeleteAFriend(int id)
        {
            var friend = _context.friends.Find(id);
            _context.friends.Remove(friend);
            var result = _context.SaveChanges();
            return result;
            
        }

        public bool FriendExist(int friendId)
        {
            var friends = _context.friends.FirstOrDefault(f=>f.Id==friendId);
            if (friends == null)
            {
                return false;
            }
            else
            {
                return true;
            }
            
        }

        public IEnumerable<FriendsDTO> GetFriends(string userId)
        {
            var friends = _context.friends.Include(u=>u.users).Where(f => f.creatorId == userId);

            return friends.Select(f => new FriendsDTO
            {
                creator=f.users.Id,
                friendName = f.users.Name
            });
          
        }

        public int UpdateAFriend(Friends friends)
        {
            _context.friends.Update(friends);
            var result = _context.SaveChanges();
            return result;
            
        }

        #endregion
    }
}
