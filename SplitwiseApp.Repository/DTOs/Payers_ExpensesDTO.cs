using System;
using System.Collections.Generic;
using System.Text;

namespace SplitwiseApp.Repository.DTOs
{
    public class Payers_ExpensesDTO
    {
        public int Id { get; set; }
        public float paidAmount { get; set; }
        public float Share { get; set; }
        public int expenseId { get; set; }
        public string payerName { get; set; }
        public string expense { get; set; }
    }
}
