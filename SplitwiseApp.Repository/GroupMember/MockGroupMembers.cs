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

        private readonly IGroups _groups;
        private readonly AppDbContext _context;
        //private readonly IMapper _mapper;
        #endregion

        #region constructor
        public MockGroupMembers()
        {

        }
        public MockGroupMembers(AppDbContext context,IGroups groups)
        {
            _context = context;
            _groups = groups;
            
        }

        #endregion

        #region public methods
        public int AddGroupMembers(GroupMembers members)
        {
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

        public IEnumerable<UserDTO> GetGroupMembers(int groupId)
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
            List<UserDTO> usersDto=new List<UserDTO>();

            foreach(var users in members)
            {
             usersDto.Add(new UserDTO { 
                   
                    Name = users.Name,
                    Email = users.Email
                });
            }
            return usersDto;
           
        }

        public bool MemberExist(int memberId)
        {
            var member=_context.groupMember.Find(memberId);
            if (member == null)
            {
                return false;
            }
            else
                return true;
           
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
