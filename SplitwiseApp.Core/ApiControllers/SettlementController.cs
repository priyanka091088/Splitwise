using Microsoft.AspNetCore.Mvc;
using SplitwiseApp.Repository.DTOs;
using SplitwiseApp.Repository.Settlement;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SplitwiseApp.Core.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    class SettlementController : ControllerBase
    {
        private readonly ISettlement _settlement;
        public SettlementController(ISettlement settlement)
        {
            _settlement = settlement;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<SettlementDTO>>> GetSettlement(string id)
        {

            IEnumerable<SettlementDTO> settlementDtos = await _settlement.GetSettlementDetails(id);
            return Ok(settlementDtos);
        }

        [HttpPost]
        public async Task<ActionResult<SettlementDTO>> AddASettlement(SettlementDTO settlement)
        {

            SettlementDTO addSettlement = await _settlement.AddSettlementDetails(settlement);
            return Ok(addSettlement);
        }

        [HttpPut]
        public async Task<ActionResult<SettlementDTO>> UpdateSettlementDetails(SettlementDTO settlement)
        {

            SettlementDTO updateSettlement = await _settlement.UpdateSettlementDetails(settlement);
            return Ok(updateSettlement);
        }

    }
}
