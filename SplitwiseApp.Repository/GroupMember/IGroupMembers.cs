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
        public void AddGroupMembers(GroupMembers members);
        public void UpdateGroupMembers(GroupMembers memebers);
        public void DeleteGroupMembers(int id);
        public bool MemberExist(int memberId);
    }
}
