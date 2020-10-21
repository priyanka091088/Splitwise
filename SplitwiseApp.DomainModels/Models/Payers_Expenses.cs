﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SplitwiseApp.DomainModels.Models
{
    public class Payers_Expenses
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public float paidAmount { get; set; }
        [Required]
        public float Share { get; set; }
        [ForeignKey("Expenses")]
        public int expenseId { get; set; }
        //public string payerId { get; set; }
    }
}
