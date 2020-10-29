using SplitwiseApp.Repository.DTOs;
using SplitwiseApp.DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace SplitwiseApp.Repository.Friend
{
    public class MockFriends : IFriends
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public MockFriends()
        {

        }
        public MockFriends(AppDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
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

        public ActionResult<FriendsDTO> GetFriends(string userId)
        {
            return _mapper.Map<FriendsDTO>(_context.friends.Include(f => f.users).FirstOrDefaultAsync(f => f.creatorId==userId));
            
        }

        public int UpdateAFriend(Friends friends)
        {
            _context.friends.Update(friends);
            var result = _context.SaveChanges();
            return result;
            
        }
    }
}
