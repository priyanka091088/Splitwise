using System;
using System.Collections.Generic;
using System.Text;

namespace SplitwiseApp.Repository.DTOs
{
    public class SettlementDTO
    {
        public float Amount { get; set; }
        public int expenseId { get; set; }
        public int groupId { get; set; }
        public string payerId { get; set; }
    }
}
