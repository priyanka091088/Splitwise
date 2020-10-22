using SplitwiseApp.Repository.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SplitwiseApp.Repository.GroupMembers
{
    public class MockGroupMembers : IGroupMembers
    {
        public Task<GroupMembersDTO> AddGroupMembers(GroupMembersDTO members)
        {
            throw new NotImplementedException();
        }

        public Task<GroupMembersDTO> DeleteGroupMembers(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GroupMembersDTO>> GetGroupMembers(int groupId)
        {
            throw new NotImplementedException();
        }

        public Task<GroupMembersDTO> UpdateGroupMembers(GroupMembersDTO memebers)
        {
            throw new NotImplementedException();
        }
    }
}
