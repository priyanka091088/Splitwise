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
    public class SettlementController : ControllerBase
    {
        #region private variables

        private readonly ISettlement _settlement;
        #endregion

        #region constructor
        public SettlementController(ISettlement settlement)
        {
            _settlement = settlement;
        }
        #endregion

        #region API controller methods

        [HttpGet("getSettlementByUser/{id}")]
        public ActionResult<IEnumerable<SettlementDTO>> GetSettlement(string id)
        {

            IEnumerable<SettlementDTO> settlementDtos = _settlement.GetSettlementDetails(id);
            return Ok(settlementDtos);
        }

        [HttpGet("getSettlementByGroup/{groupId}")]
        public ActionResult<IEnumerable<SettlementDTO>> GetSettlementByGroupId(int groupId)
        {

            IEnumerable<SettlementDTO> settlementDtos = _settlement.GetSettlementByGroupId(groupId);
            return Ok(settlementDtos);
        }

        [HttpPost]
        public IActionResult AddASettlement(Settlement settlement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var count= _settlement.AddSettlementDetails(settlement);

            if (count==0)
            {
                return NotFound();
            }
            else
            {
                return Ok();
            }
           
        }

        [HttpPut("{settlementId}")]
        public IActionResult UpdateSettlementDetails(Settlement settlement,int settlementId)
        {
            if(!ModelState.IsValid || !(settlement.settlemntId == settlementId))
            {
                return BadRequest();
            }
            var count=_settlement.UpdateSettlementDetails(settlement);
            if (count == 0)
            {
                return NotFound();
            }
            else
                return Ok();
        }
        #endregion
    }
}
