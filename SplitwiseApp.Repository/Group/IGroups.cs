using SplitwiseApp.DomainModels.Models;
using SplitwiseApp.Repository.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SplitwiseApp.Repository.Group
{
    public interface IGroups
    {
        Task AddGroupForUser(Groups group);
        Task UpdateAGroup(Groups group);
        Task<GroupsDTO> GetGroupByGroupId(int groupId);
        Task<IEnumerable<GroupsDTO>> GetGroupByUserId(string id);
        Task DeleteAGroupById(int groupId);
        public bool GroupExist(int groupId);

    }
}
