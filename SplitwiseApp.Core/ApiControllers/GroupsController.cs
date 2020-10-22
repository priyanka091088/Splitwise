using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SplitwiseApp.Repository.DTOs;
using SplitwiseApp.Repository.Groups;

namespace SplitwiseApp.Core.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly IGroups _groups;
        public GroupsController(IGroups groups)
        {
            _groups = groups;

        }
        // GET: api/Groups
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<GroupsDTO>>> GetGroupForAUser(string userId)
        {

            IEnumerable<GroupsDTO> groupUser = await _groups.GetGroupByUserId(userId);
            return Ok(groupUser);
        }

        // GET: api/Groups
        [HttpGet("{id}")]
        public async Task<ActionResult<GroupsDTO>> GetGroup(int groupId)
        {

            GroupsDTO groupsDtos = await _groups.GetGroupByGroupId(groupId);
            return Ok(groupsDtos);
        }

        // POST: api/Groups
        [HttpPost]
        public async Task<ActionResult<GroupsDTO>> AddAGroup(GroupsDTO groups)
        {

            GroupsDTO addGroup = await _groups.AddGroupForUser(groups);
            return Ok(addGroup);
        }

        [HttpPut]
        public async Task<ActionResult<GroupsDTO>> UpdateGroup(GroupsDTO groups)
        {

            GroupsDTO updateGroup = await _groups.UpdateAGroup(groups);
            return Ok(updateGroup);
        }

        [HttpDelete]
        public async Task<ActionResult<GroupsDTO>> DeleteGroup(int groupId)
        {

            GroupsDTO deleteGroup = await _groups.DeleteAGroupById(groupId);
            return Ok(deleteGroup);
        }
    }
}
