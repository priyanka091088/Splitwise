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
    public class MockGroups : IGroups
    {
        #region private variables
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        
        #endregion

        #region constructor
        public MockGroups()
        {

        }
        public MockGroups(AppDbContext context, IMapper mapper)
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
            return result;
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
        
        public ActionResult<GroupsDTO> GetGroupByGroupId(int groupId)
        {
            return _mapper.Map<GroupsDTO>(_context.group.Include(u => u.creator).FirstOrDefault(g => g.groupId == groupId));
           
        }

        public IEnumerable<GroupsDTO> GetGroupByUserId(string id)
        {
            var userGroup = from groups in _context.@group
                            join user in _context.Users
                            on groups.creatorId equals user.Id
                            where groups.creatorId == id
                            select new GroupsDTO
                            {
                                groupName=groups.groupName,
                                groupType=groups.groupType
                            };
            List<GroupsDTO> groupDto = new List<GroupsDTO>();
            foreach(var grp in userGroup)
            {
                groupDto.Add(new GroupsDTO
                {
                    groupName=grp.groupName,
                    groupType=grp.groupType
                });
               
                
            }
            return groupDto;


        }

        public List<Groups> GetGroups()
        {
            var group = _context.group.Include(e => e.creator);
            return group.ToList();
           
        }

        public bool GroupExist(int groupId)
        {
            return _context.group.Any(g => g.groupId == groupId);
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
