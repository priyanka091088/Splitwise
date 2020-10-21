using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SplitwiseApp.DomainModels.Models
{
    public class GroupMembers
    {
        [Key]
        public int memberId { get; set; }
        [ForeignKey("Groups")]
        public int groupId { get; set; }
       // public string userId { get; set; }
    }
}
