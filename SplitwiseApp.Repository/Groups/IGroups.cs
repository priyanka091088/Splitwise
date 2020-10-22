using SplitwiseApp.Repository.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SplitwiseApp.Repository.Groups
{
    public interface IGroups
    {
        Task<GroupsDTO> AddGroupForUser(GroupsDTO group);
        Task<GroupsDTO> UpdateAGroup(GroupsDTO group);
        Task<GroupsDTO> GetGroupByGroupId(int groupId);
        Task<IEnumerable<GroupsDTO>> GetGroupByUserId(string id);
        Task<GroupsDTO> DeleteAGroupById(int groupId);

    }
}
