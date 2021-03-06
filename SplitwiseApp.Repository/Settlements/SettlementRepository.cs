﻿using SplitwiseApp.DomainModels.Models;
using SplitwiseApp.Repository.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace SplitwiseApp.Repository.Settlements
{
    public class SettlementRepository : ISettlement
    {
        #region private variables
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        #endregion

        #region constructor
        public SettlementRepository()
        {

        }
        public SettlementRepository(AppDbContext context, UserManager<ApplicationUser> userManager)
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

            var settlement = _context.settlement.Include(p => p.payer).Include(r=>r.receiver).Include(g=>g.groups).
                Where(s => s.payerId == userId || s.receiverId==userId);

            return settlement.Select(s => new SettlementDTO
            {
                Amount = s.Amount,
                receiverName = s.receiver.Name,
                payerName = s.payer.Name,
                groupName=s.groups.groupName
            });
            
        }

        public IEnumerable<SettlementDTO> GetSettlementByGroupId(int groupId)
        {

            var settlement = _context.settlement.Include(p => p.payer).Include(r=>r.receiver).
                Where(s => s.groupId == groupId);

            var groups = _context.group.FirstOrDefault(g => g.groupId == groupId);
            return settlement.Select(s => new SettlementDTO
            {
                Amount = s.Amount,
                receiverName = s.receiver.Name,
                payerName = s.payer.Name,
                groupName = groups.groupName
            });

        }

        public bool SettlementExist(int settlemntId)
        {
            return _context.settlement.Any(s => s.settlemntId == settlemntId);
           
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
