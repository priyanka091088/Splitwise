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
    public class FriendsRepository : IFriends
    {
        #region private variables
        private readonly AppDbContext _context;

        #endregion
        #region public variables

        
        #endregion

        #region constructor
        public FriendsRepository()
        {

        }
        public FriendsRepository(AppDbContext context)
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
            var friend2 = _context.friends.FirstOrDefault(f => f.creatorId == friend.friendId && f.friendId == friend.creatorId);
            _context.friends.Remove(friend);
            if (_context.SaveChanges() != 0)
            {
                var friends = _context.friends.Find(friend2.Id);
                _context.friends.Remove(friends);
            }
         
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

        public IEnumerable<FriendsDTO> GetFriendBalance(string userId)
        {
            
            var search = _context.friends.Where(f => f.creatorId == userId);

            foreach(var item in search)
            {
                float totalBalance = 0;
                float payeeShare = 0;
                float receiverShare = 0;
                float settlementShare = 0;
                float receivedSettlementShare = 0;

                var pay = _context.payees_Expenses.Where(p => p.payerId == item.creatorId && p.receiverId == item.friendId);
                var receive = _context.payees_Expenses.Where(r => r.receiverId == item.creatorId && r.payerId == item.friendId);
                var paidSettlement = _context.settlement.Where(ps => ps.payerId == item.creatorId && ps.receiverId == item.friendId);
                var receivedSettlement= _context.settlement.Where(rs => rs.receiverId == item.creatorId && rs.payerId == item.friendId);

                //to calculate balances for each friend

                foreach(var payer in pay)
                {
                    payeeShare = payeeShare + payer.Share;
                }
                foreach(var receiver in receive)
                {
                    receiverShare = receiverShare + receiver.Share;
                }
                foreach(var paid in paidSettlement)
                {
                    settlementShare = settlementShare + paid.Amount;
                }
                foreach(var received in receivedSettlement)
                {
                    receivedSettlementShare = receivedSettlementShare + received.Amount;
                }

                 totalBalance = (payeeShare + receivedSettlementShare) - (receiverShare + settlementShare);
                
                item.Balance = totalBalance;
                _context.friends.Update(item);
            }

            _context.SaveChanges();

            var friends = _context.friends.Include(u => u.users).Where(f => f.creatorId == userId);

            return friends.Select(f => new FriendsDTO
            {
                creator = f.users.Id,
                friendName = f.users.Name,
                Balance = f.Balance,
                Id=f.Id
            }) ;
            //throw new NotImplementedException();
        }

        public IEnumerable<FriendsDTO> GetFriends(string userId)
        {
            var friends = _context.friends.Include(u=>u.users).Where(f => f.creatorId == userId);

            return friends.Select(f => new FriendsDTO
            {
                Id=f.Id,
                Balance=f.Balance,
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
