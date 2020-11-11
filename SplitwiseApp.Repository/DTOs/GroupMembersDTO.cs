using System;
using System.Collections.Generic;
using System.Text;

namespace SplitwiseApp.Repository.DTOs
{
    public class GroupMembersDTO
    {
        public int memberId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public float? Balance { get; set; }
        public string memberName { get; set; }
    }
}
