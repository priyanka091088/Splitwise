using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SplitwiseApp.DomainModels.Models;
using SplitwiseApp.Repository.DTOs;
using SplitwiseApp.Repository.Group;
using SplitwiseApp.Repository.User;

namespace SplitwiseApp.Core.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly IGroups _groups;
        private readonly IUser _user;
        public GroupsController(IGroups groups,IUser users)
        {
            _groups = groups;
            _user = users;

        }

        [HttpGet]
        public List<Groups> GetGroup()
        {
            IEnumerable<Groups> groups = _groups.GetGroups();
            return groups.ToList();
        }
        // GET: api/Groups
        [HttpGet("{id}")]
        [Route("{userid}")]
        public async Task<ActionResult<IEnumerable<GroupsDTO>>> GetGroupForAUser(string userId)
        {
            if (_user.UserExists(userId))
            {
                IEnumerable<GroupsDTO> groupUser = await _groups.GetGroupByUserId(userId);
                return Ok(groupUser);
            }
            return NotFound();
        }

        // GET: api/Groups
        [HttpGet("{id}")]
        public async Task<ActionResult<GroupsDTO>> GetGroup(int groupId)
        {
            if (_groups.GroupExist(groupId))
            {
                GroupsDTO groupsDtos = await _groups.GetGroupByGroupId(groupId);
                return Ok(groupsDtos);
            }
            return NotFound();
        }

        // POST: api/Groups
        [HttpPost]
        public IActionResult AddAGroup(Groups groups)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
             _groups.AddGroupForUser(groups);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateGroup(Groups groups)
        {
            if (_groups.GroupExist(groups.groupId))
            {
                _groups.UpdateAGroup(groups);
                return Ok();
            }
            return NotFound();
        }

        [HttpDelete]
        public IActionResult DeleteGroup(int groupId)
        {
            if (_groups.GroupExist(groupId))
            {
                _groups.DeleteAGroupById(groupId);
                return Ok();
            }
            return NotFound();
        }
    }
}
