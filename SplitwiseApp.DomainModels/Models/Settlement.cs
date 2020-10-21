using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SplitwiseApp.DomainModels.Models
{
    public class Settlement
    {
        [Key]
        public int settlemntId { get; set; }
        [Required]
        public float Amount { get; set; }
       
        [ForeignKey("Expenses")]
        public int expenseId { get; set; }
        [ForeignKey("Groups")]
        public int groupId { get; set; }

        /* public string payerId { get; set; }
        public string receiverId { get; set; }*/
    }
}
