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
    public class GroupMembersController : ControllerBase
    {
        #region private variables
        private readonly IGroupMembers _members;
        private readonly IGroups _groups;
        #endregion

        #region constructor
        public GroupMembersController(IGroupMembers members,IGroups groups)
        {
            _members = members;
            _groups = groups;
        }
        #endregion

        #region API controller methods

        [HttpGet("{groupId}")]
        public ActionResult<UserDTO> GetMembersOfAGroup(int groupId)
        {
            if (_groups.GroupExist(groupId))
            {
                IEnumerable<UserDTO> memberDtos = _members.GetGroupMembers(groupId);
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
            var count = _members.AddGroupMembers(members);

            if (count == 0)
            {
                return BadRequest();

            }
            else
                return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMembers(GroupMembers members,int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (!_members.MemberExist(members.memberId) && !(members.groupId == id))
            {
                return BadRequest();

            }
            var count = _members.UpdateGroupMembers(members);

            if (count == 0)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpDelete("{memberId}")]
        public IActionResult DeleteMembers(int memberId)
        {
            if (!_members.MemberExist(memberId))
            {
                return BadRequest();
            }

            var count = _members.DeleteGroupMembers(memberId);

            if (count == 0)
            {
                return NotFound();
            }
            return Ok();
            
        }
        #endregion
    }
}
