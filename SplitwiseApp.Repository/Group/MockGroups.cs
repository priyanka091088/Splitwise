using Microsoft.EntityFrameworkCore;
using SplitwiseApp.DomainModels.Models;
using SplitwiseApp.Repository.DTOs;
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
        public MockGroups()
        {

        }
        public MockGroups(AppDbContext context)
        {
            _context = context;
        }
        public Task AddGroupForUser(Groups group)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAGroupById(int groupId)
        {
            throw new NotImplementedException();
        }

        public Task<GroupsDTO> GetGroupByGroupId(int groupId)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public Task UpdateAGroup(Groups group)
        {
            throw new NotImplementedException();
        }
    }
}
