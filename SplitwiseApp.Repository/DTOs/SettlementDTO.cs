using System;
using System.Collections.Generic;
using System.Text;

namespace SplitwiseApp.Repository.DTOs
{
    public class SettlementDTO
    {
        public float Amount { get; set; }
        public int expenseId { get; set; }
        public string payerName { get; set; }
        public string receiverName { get; set; }
        public string expense { get; set; }
        public string groupName { get; set; }
    }
}
