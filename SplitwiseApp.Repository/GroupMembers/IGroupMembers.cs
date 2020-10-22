using SplitwiseApp.Repository.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SplitwiseApp.Repository.GroupMembers
{
    public interface IGroupMembers
    {
        Task<IEnumerable<GroupMembersDTO>> GetGroupMembers(int groupId);
        Task<GroupMembersDTO> AddGroupMembers(GroupMembersDTO members);
        Task<GroupMembersDTO> UpdateGroupMembers(GroupMembersDTO memebers);
        Task<GroupMembersDTO> DeleteGroupMembers(int id);
    }
}
