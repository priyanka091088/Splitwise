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
        void AddGroupForUser(Groups group);
        void UpdateAGroup(Groups group);
        Task<GroupsDTO> GetGroupByGroupId(int groupId);
        Task<IEnumerable<GroupsDTO>> GetGroupByUserId(string id);
        void DeleteAGroupById(int groupId);
        public bool GroupExist(int groupId);

    }
}
