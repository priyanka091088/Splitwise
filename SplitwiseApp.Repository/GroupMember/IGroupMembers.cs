using Microsoft.AspNetCore.Mvc;
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
        IEnumerable<GroupMembersDTO> GetGroupMembers(int groupId);
        public int AddGroupMembers(GroupMembers members);
        public int UpdateGroupMembers(GroupMembers memebers);
        public int DeleteGroupMembers(int id);
        public bool MemberExist(int memberId);
    }
}
