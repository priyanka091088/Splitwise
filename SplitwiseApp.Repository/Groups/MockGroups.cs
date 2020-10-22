using SplitwiseApp.Repository.DTOs;
using SplitwiseApp.Repository.GroupMembers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SplitwiseApp.Repository.Groups
{
    public class MockGroups : IGroups
    {
        private readonly IGroupMembers members;
        public MockGroups(IGroupMembers _members)
        {
            members = _members;
        }
        public Task<GroupsDTO> AddGroupForUser(GroupsDTO group)
        {
            throw new NotImplementedException();
        }

        public Task<GroupsDTO> DeleteAGroupById(int groupId)
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

        public Task<GroupsDTO> UpdateAGroup(GroupsDTO group)
        {
            throw new NotImplementedException();
        }
    }
}
