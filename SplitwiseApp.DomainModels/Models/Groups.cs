using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SplitwiseApp.DomainModels.Models
{
    public class Groups
    {
        [Key]
        public int groupId { get; set; }
        [Required]
        public string groupName { get; set; }
        [Required]
        public string groupType { get; set; }


        public string creatorId { get; set; }
        [ForeignKey("creatorId")]
        public ApplicationUser creator { get; set; }
    }
}
