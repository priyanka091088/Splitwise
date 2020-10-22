using SplitwiseApp.Repository.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SplitwiseApp.Repository.Settlement
{
    public interface ISettlement
    {
        Task<IEnumerable<SettlementDTO>> GetSettlementDetails(string userId);
        Task<SettlementDTO> AddSettlementDetails(SettlementDTO settlement);
        Task<SettlementDTO> UpdateSettlementDetails(SettlementDTO settlement);
    }
}
