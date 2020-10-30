using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SplitwiseApp.DomainModels.Models;
using SplitwiseApp.Repository.DTOs;
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
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        
        public MockGroups()
        {

        }
        public MockGroups(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
          
        }
        public int AddGroupForUser(Groups group)
        {
            
             _context.group.Add(group);
            var result= _context.SaveChanges();
            return result;
        }

        public int DeleteAGroupById(int groupId)
        {
            
            var groups =_context.group.Find(groupId);
            _context.group.Remove(groups);
            var result = _context.SaveChanges();
            return result;
            //throw new NotImplementedException();
        }
        
        public ActionResult<GroupsDTO> GetGroupByGroupId(int groupId)
        {
            return _mapper.Map<GroupsDTO>(_context.group.Include(u => u.creator).FirstOrDefault(g => g.groupId == groupId));
           
        }

        public Task<IEnumerable<GroupsDTO>> GetGroupByUserId(string id)
        {
            throw new NotImplementedException();
        }

        public List<Groups> GetGroups()
        {
            var group = _context.group.Include(e => e.creator);
            return group.ToList();
           // return _context.group.ToListAsync();
        }

        public bool GroupExist(int groupId)
        {
            var group = _context.group.Where(g => g.groupId == groupId);
            if (group == null)
            {
                return false;
            }
            else
                return true;
        }

        public int UpdateAGroup(Groups group)
        {
            _context.group.Update(group);
            var result = _context.SaveChanges();
            return result;
            
        }
    }
}
