using SplitwiseApp.DomainModels.Models;
using SplitwiseApp.Repository.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SplitwiseApp.Repository.Settlements
{
    public interface ISettlement
    {
        IEnumerable<SettlementDTO> GetSettlementDetails(string userId);
        IEnumerable<SettlementDTO> GetSettlementByGroupId(int groupId);
        public int AddSettlementDetails(Settlement settlement);
        public int UpdateSettlementDetails(Settlement settlement);
        public bool SettlementExist(int settlemntId);
    }
}
