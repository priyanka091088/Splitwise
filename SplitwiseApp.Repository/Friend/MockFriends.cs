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
        private readonly IMapper _mapper;

        #endregion

        #region constructor
        public MockFriends()
        {

        }
        public MockFriends(AppDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        #endregion

        #region public methods
        public int AddAFriend(Friends friends)
        {
            _context.friends.Add(friends);
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
            var friend = _context.friends.Find(friendId);
            if (friend == null)
            {
                return false;
            }
            else
                return true;
            
        }

        public IEnumerable<UserDTO> GetFriends(string userId)
        {
            var friends = from user in _context.Users
                          join frnd in _context.friends
                          on user.Id equals frnd.friendId
                          where frnd.creatorId == userId
                          select new UserDTO
                          {
                              Name = user.Name
                          };
            List<UserDTO> usersDto = new List<UserDTO>();

            foreach(var friend in friends)
            {
                usersDto.Add(new UserDTO
                {

                    Name = friend.Name,
                });
               
            }
            return usersDto;

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
