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
        public float? Balance { get; set; }

        public int groupId { get; set; }
        [ForeignKey("groupId")]
        public Groups groups { get; set; }


        public string userId { get; set; }
        [ForeignKey("userId")]
        public ApplicationUser users { get; set; }
    }
}
