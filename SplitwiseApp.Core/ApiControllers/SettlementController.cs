using Microsoft.AspNetCore.Mvc;
using SplitwiseApp.DomainModels.Models;
using SplitwiseApp.Repository.DTOs;
using SplitwiseApp.Repository.Settlements;
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
        public IActionResult AddASettlement(Settlement settlement)
        {

            _settlement.AddSettlementDetails(settlement);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateSettlementDetails(Settlement settlement)
        {

            _settlement.UpdateSettlementDetails(settlement);
            return Ok();
        }

    }
}
