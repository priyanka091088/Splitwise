using System;
using System.Collections.Generic;
using System.Text;

namespace SplitwiseApp.Repository.DTOs
{
    public class ExpensesDTO
    {
        public int expenseId { get; set; }
        public string Description { get; set; }
        public string Currency { get; set; }
        public float Amount { get; set; }
        public string SplitBy { get; set; }
        public int groupId { get; set; }
        public string creatorId { get; set; }
    }
}
