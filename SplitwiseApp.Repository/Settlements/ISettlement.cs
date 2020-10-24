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
        public Task AddSettlementDetails(Settlement settlement);
        public Task UpdateSettlementDetails(Settlement settlement);
        public bool SettlementExist(int settlemntId);
    }
}
