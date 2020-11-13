using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SplitwiseApp.DomainModels.Models;
using SplitwiseApp.Repository.DTOs;
using SplitwiseApp.Repository.Expense;
using SplitwiseApp.Repository.GroupMember;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitwiseApp.Repository.Group
{
    public class GroupsRepository : IGroups
    {
        #region private variables
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        
        #endregion

        #region constructor
        public GroupsRepository()
        {

        }
        public GroupsRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            
        }
        #endregion

        #region public methods
        public int AddGroupForUser(Groups group)
        {
            
             _context.group.Add(group);
            if (_context.SaveChanges() != 0)
            {
                GroupMembers member = new GroupMembers
                {
                    groupId = group.groupId,
                    userId = group.creatorId
                };
                _context.groupMember.Add(member);
            }
           
            var result= _context.SaveChanges();
            if (result == 0)
            {
                return 0;
            }
            else
                return group.groupId;
        }

        public int DeleteAGroupById(int groupId)
        {
            //remove the particular group
            var groups = _context.group.Find(groupId);
            _context.group.Remove(groups);

            //remove the members of the group
            IEnumerable<GroupMembers> members = _context.groupMember.Where(m => m.groupId == groupId);
            _context.groupMember.RemoveRange(members);

            //remove the expenses frelated to the group
            IEnumerable<Expenses> expense = _context.expenses.Where(e => e.groupId == groupId);
            _context.expenses.RemoveRange(expense);

            //loop for removing all the payers,payees and settlements related to th particular expense
            foreach(var item in expense)
                {
                IEnumerable<Payers_Expenses> payer = _context.payers_Expenses.Where(p => p.expenseId == item.expenseId);
                _context.payers_Expenses.RemoveRange(payer);

                IEnumerable<Payees_Expenses> payee = _context.payees_Expenses.Where(pa => pa.expenseId == item.expenseId);
                _context.payees_Expenses.RemoveRange(payee);

                IEnumerable<Settlement> settle = _context.settlement.Where(s => s.expenseId == item.expenseId);
                _context.settlement.RemoveRange(settle);
                
                }
            var result = _context.SaveChanges();
            return result;
           
        }

        public IEnumerable<GroupMembersDTO> GetGroupBalance(int groupId)
        { 

            
            var members = _context.groupMember.Where(m => m.groupId == groupId);

            foreach(var item in members)
            {
                float totalBalance = 0;
                float payeeShare = 0;
                float receiverShare = 0;
                float settlementShare = 0;
                float receivedSettlementShare = 0;

                var expenses = _context.expenses.Where(e => e.groupId == groupId);
                var paid = _context.settlement.Where(ps => ps.groupId == item.groupId && ps.payerId == item.userId);
                var received = _context.settlement.Where(rs => rs.groupId == item.groupId && rs.receiverId == item.userId);
                foreach(var expense in expenses)
                {
                    var payer = _context.payees_Expenses.Where(p => p.payerId == item.userId && p.expenseId == expense.expenseId);
                    var receiver = _context.payees_Expenses.Where(r => r.receiverId == item.userId && r.expenseId == expense.expenseId);

                    foreach(var p in payer)
                    {
                        payeeShare = payeeShare + p.Share;
                    }
                    foreach(var r in receiver)
                    {
                        receiverShare = receiverShare + r.Share;
                    }
                    foreach(var pa in paid)
                    {
                        settlementShare = settlementShare + pa.Amount;
                    }
                    foreach(var ra in received)
                    {
                        receivedSettlementShare = receivedSettlementShare + ra.Amount;
                    }
                }
                totalBalance = (payeeShare + receivedSettlementShare) - (receiverShare + settlementShare);
                item.Balance = totalBalance;
                _context.groupMember.Update(item);
            }

            _context.SaveChanges();

            var search = _context.groupMember.Include(u=>u.users).Where(g => g.groupId == groupId);

            return search.Select(s => new GroupMembersDTO
            {
                Balance=s.Balance,
                memberName=s.users.Name
                
            });
        }

        public ActionResult<GroupsDTO> GetGroupByGroupId(int groupId)
        {
            return _mapper.Map<GroupsDTO>(_context.group.Include(u => u.creator).FirstOrDefault(g => g.groupId == groupId));
           
        }

        public IEnumerable<GroupsDTO> GetGroupByUserId(string id)
        {
            var groups = _context.group.Where(g => g.creatorId == id);

            return groups.Select(g => new GroupsDTO
            {
                groupId=g.groupId,
                groupName = g.groupName,
                groupType = g.groupType
            });
        }

        public List<Groups> GetGroups()
        {
            var group = _context.group.Include(e => e.creator);
            return group.ToList();
           
        }

        public bool GroupExist(int groupId)
        {
            var groups = _context.group.FirstOrDefault(g=>g.groupId==groupId);
            if (groups == null)
            {
                return false;
            }
            else
            {
                return true;
            }
            
        }

        public int UpdateAGroup(Groups group)
        {
            _context.group.Update(group);
            var result = _context.SaveChanges();
            return result;
            
        }
        #endregion
    }
}
