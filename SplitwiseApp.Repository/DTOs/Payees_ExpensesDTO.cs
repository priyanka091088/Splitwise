using System;
using System.Collections.Generic;
using System.Text;

namespace SplitwiseApp.Repository.DTOs
{
    public class Payees_ExpensesDTO
    {
        public int pId { get; set; }
        public float Share { get; set; }
        public int expenseId { get; set; }
        public string payerName { get; set; }
        public string receiverName { get; set; }
        public string expense { get; set; }
    }
}
