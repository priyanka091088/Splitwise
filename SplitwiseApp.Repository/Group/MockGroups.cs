using SplitwiseApp.DomainModels.Models;
using SplitwiseApp.Repository.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SplitwiseApp.Repository.Group
{
    public class MockGroups : IGroups
    {
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
