using Microsoft.AspNetCore.Mvc;
using SplitwiseApp.DomainModels.Models;
using SplitwiseApp.Repository.DTOs;
using SplitwiseApp.Repository.Group;
using SplitwiseApp.Repository.GroupMember;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SplitwiseApp.Core.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    class GroupMembersController:ControllerBase
    {
        private readonly IGroupMembers _members;
        private readonly IGroups _groups;
        public GroupMembersController(IGroupMembers members,IGroups groups)
        {
            _members = members;
            _groups = groups;
        }

        [HttpGet("{id}")]
        public IActionResult GetMembersOfAGroup(int groupId)
        {
            if (_groups.GroupExist(groupId))
            {
                var memberDtos = _members.GetGroupMembers(groupId);
                return Ok(memberDtos);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult AddMember(GroupMembers members)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _members.AddGroupMembers(members);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateMembers(GroupMembers members)
        {
            if (_members.MemberExist(members.memberId))
            {
                _members.UpdateGroupMembers(members);
                return Ok();
            }
            return NotFound();
        }

        [HttpDelete]
        public IActionResult DeleteMembers(int id)
        {
            if (_members.MemberExist(id))
            {
                _members.DeleteGroupMembers(id);
                return Ok();
            }
            return NotFound();
        }
    }
}
