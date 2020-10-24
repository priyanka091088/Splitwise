using SplitwiseApp.DomainModels.Models;
using SplitwiseApp.Repository.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SplitwiseApp.Repository.Settlements
{
    public class MockSettlement : ISettlement
    {
        public Task AddSettlementDetails(Settlement settlement)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SettlementDTO>> GetSettlementDetails(string userId)
        {
            throw new NotImplementedException();
        }

        public bool SettlementExist(int settlemntId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateSettlementDetails(Settlement settlement)
        {
            throw new NotImplementedException();
        }
    }
}
