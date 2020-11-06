using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SplitwiseApp.DomainModels.Models;
using SplitwiseApp.Repository.DTOs;
using SplitwiseApp.Repository.Group;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitwiseApp.Repository.GroupMember
{
    public class MockGroupMembers : IGroupMembers
    {
        #region private variables

        private readonly AppDbContext _context;
        #endregion

        #region constructor
        public MockGroupMembers()
        {

        }
        public MockGroupMembers(AppDbContext context)
        {
            _context = context;
            
        }

        #endregion

        #region public methods
        public int AddGroupMembers(GroupMembers members)
        {
            List<GroupMembers> search = new List<GroupMembers>();

            //to check if that member already exists in the group or not
            var res = _context.groupMember.Where(m => m.groupId == members.groupId && m.userId == members.userId);

            search.AddRange(res);
            //will not add the member if member already exists
            if (search.Count != 0)
            {
                return 0;
            }

            _context.groupMember.Add(members);
            var result = _context.SaveChanges();
            return result;
            
        }

        public int DeleteGroupMembers(int id)
        {
           var member= _context.groupMember.Find(id);
            _context.groupMember.Remove(member);
            var result = _context.SaveChanges();
            return result;
            
        }

        public IEnumerable<GroupMembersDTO> GetGroupMembers(int groupId)
        {
            var members = from user in _context.Users
                          join member in _context.groupMember
                          on user.Id equals member.userId
                          where member.groupId == groupId
                          select new UserDTO
                          {
                              Email=user.Email,
                              Name=user.Name
                          };
            List<GroupMembersDTO> membersDto=new List<GroupMembersDTO>();

            foreach(var users in members)
            {
             membersDto.Add(new GroupMembersDTO { 
                   
                    Name = users.Name,
                    Email = users.Email
                });
            }
            return membersDto;
           
        }

        public bool MemberExist(int memberId)
        {
            return _context.groupMember.Any(m => m.memberId == memberId);
          
        }

        public int UpdateGroupMembers(GroupMembers members)
        {
            _context.groupMember.Update(members);
            var result = _context.SaveChanges();
            return result;
            
        }

        #endregion
    }
}
