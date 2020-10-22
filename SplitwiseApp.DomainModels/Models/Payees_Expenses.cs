using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SplitwiseApp.DomainModels.Models
{
    public class Payees_Expenses
    {
        [Key]
        public int pId { get; set; }
        [Required]
        public float Share { get; set; }
        
        public int? expenseId { get; set; }
        [ForeignKey("expenseId")]
        public Expenses expenses { get; set; }


        public string payerId { get; set; }
        [ForeignKey("payerId")]
        public ApplicationUser payer { get; set; }

        public string receiverId { get; set; }
        [ForeignKey("receiverId")]
        public ApplicationUser receiever { get; set; }
    }
}
