using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SplitwiseApp.DomainModels.Models;
using SplitwiseApp.Repository.DTOs;
using SplitwiseApp.Repository.Group;
using SplitwiseApp.Repository.GroupMember;
using SplitwiseApp.Repository.User;

namespace SplitwiseApp.Core.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        #region private variables
        private readonly IGroups _groups;
        private readonly IUser _user;
        private readonly AppDbContext _context;
        #endregion

        #region constructor
        public GroupsController(IGroups groups,IUser users,AppDbContext context)
        {
            _groups = groups;
            _user = users;
            _context = context;
         
        }
        #endregion

        #region API controller methods

        [HttpGet]
        public List<Groups> GetGroup()
        {
            IEnumerable<Groups> groups = _groups.GetGroups();
            return groups.ToList();
        }
        // GET: api/Groups
      [HttpGet("{userId}")]
      [Route("getByUser/{userId}")]
        public ActionResult<GroupsDTO> GetGroupsForAUser(string userId)
        {
            if (_user.UserExists(userId))
            {
                IEnumerable<GroupsDTO> groupUser = _groups.GetGroupByUserId(userId);
                return Ok(groupUser);
            }
            return NotFound();
        }

        // GET: api/Groups
        [HttpGet("{id}")]
        [Route("getByGroupid/{id}")]
        public ActionResult<GroupsDTO> GetGroup(int id)
        {
            if (_groups.GroupExist(id))
            {
                return _groups.GetGroupByGroupId(id);
            }

            return BadRequest();
        }

        // POST: api/Groups
        [HttpPost]
        public IActionResult AddAGroup(Groups groups)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
             var count= _groups.AddGroupForUser(groups);
            if (count==0 )
            {
                return NotFound();
                
            }
            else
                return Ok();

        }

        [HttpPut("{id}")]
        public IActionResult UpdateGroup(Groups groups,int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (!_groups.GroupExist(groups.groupId) && !(groups.groupId == id))
            {
                return BadRequest();
               
            }
            var count = _groups.UpdateAGroup(groups);
            if (count == 0)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpDelete("{groupId}")]
        public IActionResult DeleteGroup(int groupId)
        {
            if (!_groups.GroupExist(groupId))
            {
                return BadRequest();
            }
            var count= _groups.DeleteAGroupById(groupId);
            if (count == 0)
            {
                return NotFound();
            }
            return Ok();
        }
        #endregion
    }
}
