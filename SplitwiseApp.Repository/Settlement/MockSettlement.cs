﻿using SplitwiseApp.Repository.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SplitwiseApp.Repository.Settlement
{
    public class MockSettlement : ISettlement
    {
        public Task<SettlementDTO> AddSettlementDetails(SettlementDTO settlement)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SettlementDTO>> GetSettlementDetails(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<SettlementDTO> UpdateSettlementDetails(SettlementDTO settlement)
        {
            throw new NotImplementedException();
        }
    }
}
