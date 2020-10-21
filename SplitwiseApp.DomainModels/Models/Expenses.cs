﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SplitwiseApp.DomainModels.Models
{
    public class Expenses
    {
        [Key]
        public int expenseId { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public float Amount { get; set; }
        [Required]
        public string Currency { get; set; }
        [Required]
        public string SplitBy { get; set; }
        [ForeignKey("Groups")]
        public int groupId { get; set; }
        public string creatorId { get; set; }
    }
}
