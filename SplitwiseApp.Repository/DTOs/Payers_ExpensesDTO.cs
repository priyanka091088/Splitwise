using System;
using System.Collections.Generic;
using System.Text;

namespace SplitwiseApp.Repository.DTOs
{
    public class Payers_ExpensesDTO
    {
        public float paidAmount { get; set; }
        public float Share { get; set; }
        public int expenseId { get; set; }
        public string payerId { get; set; }
    }
}
