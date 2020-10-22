using Microsoft.AspNetCore.Mvc;
using SplitwiseApp.Repository.DTOs;
using SplitwiseApp.Repository.GroupMembers;
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
        public GroupMembersController(IGroupMembers members)
        {
            _members = members;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<GroupMembersDTO>>> GetMembers(int id)
        {

            IEnumerable<GroupMembersDTO> memberDtos = await _members.GetGroupMembers(id);
            return Ok(memberDtos);
        }

        [HttpPost]
        public async Task<ActionResult<GroupMembersDTO>> AddMember(GroupMembersDTO members)
        {

            GroupMembersDTO addMember = await _members.AddGroupMembers(members);
            return Ok(addMember);
        }

        [HttpPut]
        public async Task<ActionResult<GroupMembersDTO>> UpdateMembers(GroupMembersDTO members)
        {

            GroupMembersDTO updateMembers = await _members.UpdateGroupMembers(members);
            return Ok(updateMembers);
        }

        [HttpDelete]
        public async Task<ActionResult<GroupMembersDTO>> DeleteMembers(int id)
        {

            GroupMembersDTO deleteMembers = await _members.DeleteGroupMembers(id);
            return Ok(deleteMembers);
        }
    }
}
