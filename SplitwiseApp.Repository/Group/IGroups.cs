using Microsoft.AspNetCore.Mvc;
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
        List<Groups> GetGroups();
        int AddGroupForUser(Groups group);
        int UpdateAGroup(Groups group);
        ActionResult<GroupsDTO> GetGroupByGroupId(int groupId);
        IEnumerable<GroupsDTO> GetGroupByUserId(string id);
        int DeleteAGroupById(int groupId);
        public bool GroupExist(int groupId);

    }
}
