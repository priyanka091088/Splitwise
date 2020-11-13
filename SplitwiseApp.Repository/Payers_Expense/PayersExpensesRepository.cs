using SplitwiseApp.DomainModels.Models;
using SplitwiseApp.Repository.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SplitwiseApp.Repository.Payers_Expense
{
    public class PayersExpensesRepository : IPayersExpenses
    {
        #region private Variables

        private readonly AppDbContext _context;

        #endregion

        #region Constructor
        public PayersExpensesRepository()
        {

        }
        public PayersExpensesRepository(AppDbContext context)
        {
            _context = context;
        }

        #endregion

        #region public methods
        public int AddPayersExpenses(Payers_Expenses payerExpense)
        {
            _context.payers_Expenses.Add(payerExpense);
            var result = _context.SaveChanges();
            return result;
            
        }

        public int DeletePayersExpenses(int id)
        {
            var payer = _context.payers_Expenses.Find(id);
            _context.payers_Expenses.Remove(payer);
            var result = _context.SaveChanges();
            return result;
           
        }

        public IEnumerable<Payers_ExpensesDTO> GetPayersExpensesByExpenseId(int expenseId)
        {
            var payers = _context.payers_Expenses.Include(p => p.payer).Where(p => p.expenseId == expenseId);

            var expenses = _context.expenses.FirstOrDefault(e => e.expenseId == expenseId);
            return payers.Select(p => new Payers_ExpensesDTO
            {
                paidAmount = p.paidAmount,
                Share = p.Share,
                payerName = p.payer.Name,
                expense = expenses.Description
            });
           
        }

        public int UpdatePayersExpenses(Payers_Expenses payerExpense)
        {
            _context.payers_Expenses.Update(payerExpense);
            var result = _context.SaveChanges();
            return result;
            
        }

        public bool PayerExists(int id)
        {
            return _context.payers_Expenses.Any(p =>p.Id == id);
          
        }

        public IEnumerable<Payers_ExpensesDTO> GetPayersByUserId(string userId)
        {
            var payers = _context.payers_Expenses.Include(e => e.expenses).Include(p => p.payer).
               Where(p => p.payerId == userId );
            return payers.Select(p => new Payers_ExpensesDTO
            {
                Share = p.Share,
                payerName = p.payer.Name,
               paidAmount=p.paidAmount,
                expense = p.expenses.Description
            });

           
        }
        #endregion
    }
}
