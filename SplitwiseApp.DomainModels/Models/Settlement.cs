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
       
        
        public int expenseId { get; set; }
        [ForeignKey("Expenses")]
        public Expenses expenses { get; set; }
        
        public int? groupId { get; set; }
        [ForeignKey("groupId")]
        public Groups groups { get; set; }


        public string payerId { get; set; }
        [ForeignKey("payerId")]
        public ApplicationUser payer { get; set; }

        public string receiverId { get; set; }
        [ForeignKey("receiverId")]
        public ApplicationUser receiver { get; set; }
    }
}
