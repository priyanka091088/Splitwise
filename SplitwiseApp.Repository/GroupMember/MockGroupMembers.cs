using SplitwiseApp.DomainModels.Models;
using SplitwiseApp.Repository.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SplitwiseApp.Repository.GroupMember
{
    public class MockGroupMembers : IGroupMembers
    {
        public Task AddGroupMembers(GroupMembers members)
        {
            throw new NotImplementedException();
        }

        public Task DeleteGroupMembers(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GroupMembersDTO>> GetGroupMembers(int groupId)
        {
            throw new NotImplementedException();
        }

        public bool MemberExist(int memberId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateGroupMembers(GroupMembers members)
        {
            throw new NotImplementedException();
        }
    }
}
