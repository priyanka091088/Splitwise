using SplitwiseApp.DomainModels.Models;
using SplitwiseApp.Repository.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SplitwiseApp.Repository.Payees_Expense
{
    public class PayeesExpensesRepository : IPayeeExpenses
    {
        #region private variable
        private readonly AppDbContext _context;
        #endregion

        #region constructor
        public PayeesExpensesRepository()
        {

        }

        public PayeesExpensesRepository(AppDbContext context)
        {
            _context = context;
        }
        #endregion

        #region public methods
        public int AddPayeesExpenses(Payees_Expenses payeesExpense)
        {
            _context.payees_Expenses.Add(payeesExpense);
            var result = _context.SaveChanges();
            return result;
            
        }

        public int DeletePayeesExpenses(int id)
        {
            var payee = _context.payees_Expenses.Find(id);
            _context.payees_Expenses.Remove(payee);
            var result = _context.SaveChanges();
            return result;
            
        }

        public IEnumerable<Payees_ExpensesDTO> GetPayeesByUserId(string userId)
        {
            var payees = _context.payees_Expenses.Include(e => e.expenses).Include(r => r.receiever).Include(p=>p.payer).
                Where(p => p.payerId == userId || p.receiverId==userId);
            return payees.Select(p => new Payees_ExpensesDTO
            {
                Share = p.Share,
                payerName = p.payer.Name,
                receiverName = p.receiever.Name,
                expense = p.expenses.Description
            });

            //throw new NotImplementedException();
        }
        public IEnumerable<Payees_ExpensesDTO> GetPayeesExpensesByExpenseId(int expenseId)
        {
            var payees = _context.payees_Expenses.Include(p => p.payer).Include(r=>r.receiever).
                Where(p => p.expenseId == expenseId);

            var expense = _context.expenses.FirstOrDefault(e => e.expenseId == expenseId);
            return payees.Select(p => new Payees_ExpensesDTO
            {
                Share = p.Share,
                payerName = p.payer.Name,
                receiverName = p.receiever.Name,
                expense = expense.Description
            });
          
        }

        public bool PayeeExists(int id)
        {
            return _context.payees_Expenses.Any(pa => pa.pId == id);
          
           
        }

        public int UpdatePayeesExpenses(Payees_Expenses payeesExpense)
        {
            _context.payees_Expenses.Update(payeesExpense);
            var result = _context.SaveChanges();
            return result;
            
        }
        #endregion
    }
}
