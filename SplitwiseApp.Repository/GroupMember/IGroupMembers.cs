using SplitwiseApp.DomainModels.Models;
using SplitwiseApp.Repository.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SplitwiseApp.Repository.GroupMember
{
    public interface IGroupMembers
    {
        Task<IEnumerable<GroupMembersDTO>> GetGroupMembers(int groupId);
        public Task AddGroupMembers(GroupMembers members);
        public Task UpdateGroupMembers(GroupMembers memebers);
        public Task DeleteGroupMembers(int id);
        public bool MemberExist(int memberId);
    }
}
