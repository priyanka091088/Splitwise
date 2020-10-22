using System;
using System.Collections.Generic;
using System.Text;

namespace SplitwiseApp.Repository.DTOs
{
    public class Payees_ExpensesDTO
    {
        public float Share { get; set; }
        public int expenseId { get; set; }
        public string payerId { get; set; }
        public string receiverId { get; set; }
    }
}
