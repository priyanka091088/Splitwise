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
        Task<IEnumerable<SettlementDTO>> GetSettlementDetails(string userId);
        public void AddSettlementDetails(Settlement settlement);
        public void UpdateSettlementDetails(Settlement settlement);
        public bool SettlementExist(int settlemntId);
    }
}
