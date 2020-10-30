using SplitwiseApp.DomainModels.Models;
using SplitwiseApp.Repository.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
namespace SplitwiseApp.Repository.Settlements
{
    public class MockSettlement : ISettlement
    {
        #region private variables
        private readonly AppDbContext _context;
        #endregion

        #region constructor
        public MockSettlement()
        {

        }
        public MockSettlement(AppDbContext context)
        {
            _context = context;
        }
        public int AddSettlementDetails(Settlement settlement)
        {
            _context.settlement.Add(settlement);
            var result = _context.SaveChanges();
            return result;
            
        }
        #endregion

        #region public methods
        public IEnumerable<SettlementDTO> GetSettlementDetails(string userId)
        {
            var settleup = from settlements in _context.settlement
                           join user in _context.Users
                           on settlements.payerId equals user.Id
                           where settlements.payerId == userId
                           select new SettlementDTO
                           {
                               Amount = settlements.Amount,
                               expense = settlements.expenses.Description,
                               receiverName=settlements.receiver.Name,
                               payerName = settlements.payer.Name
                           };
            List<SettlementDTO> settlementDto = new List<SettlementDTO>();
            foreach(var settle in settleup)
            {
                settlementDto.Add(new SettlementDTO
                {
                    Amount =settle.Amount,
                    expense=settle.expense,
                    receiverName=settle.receiverName,
                    payerName=settle.payerName
            });
            }
            return settlementDto;
            
        }

        public IEnumerable<SettlementDTO> GetSettlementDetailsByGroupId(int groupId)
        {
            var settleup = from settlements in _context.settlement
                           join groups in _context.@group
                           on settlements.groupId equals groups.groupId
                           where settlements.groupId == groupId
                           select new SettlementDTO
                           {
                               Amount = settlements.Amount,
                               expense = settlements.expenses.Description,
                               receiverName = settlements.receiver.Name,
                               payerName = settlements.payer.Name,
                               groupName=settlements.groups.groupName
                           };
            List<SettlementDTO> settlementDto = new List<SettlementDTO>();
            foreach (var settle in settleup)
            {
                settlementDto.Add(new SettlementDTO
                {
                    Amount = settle.Amount,
                    expense = settle.expense,
                    receiverName = settle.receiverName,
                    payerName = settle.payerName,
                    groupName=settle.groupName
                });
            }
            return settlementDto;

        }

        public bool SettlementExist(int settlemntId)
        {
            var settlement = _context.settlement.Find(settlemntId);
            if (settlement == null)
            {
                return false;
            }
            else
                return true;
            
        }

        public int UpdateSettlementDetails(Settlement settlement)
        {
            _context.settlement.Update(settlement);
            var result = _context.SaveChanges();
            return result;
            
        }

        #endregion
    }
}
