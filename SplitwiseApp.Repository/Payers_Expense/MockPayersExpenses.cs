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
    public class MockPayersExpenses : IPayersExpenses
    {
        private readonly AppDbContext _context;

        public MockPayersExpenses()
        {

        }
        public MockPayersExpenses(AppDbContext context)
        {
            _context = context;
        }
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
            
            var payers = from payer in _context.payers_Expenses
                         join expense in _context.expenses
                         on payer.expenseId equals expense.expenseId
                         where payer.expenseId == expenseId
                         select new Payers_ExpensesDTO
                         {
                             paidAmount = payer.paidAmount,
                             Share = payer.Share,
                             payerName = payer.payer.Name,
                             expense = payer.expenses.Description
                          };
            List<Payers_ExpensesDTO> payersDto = new List<Payers_ExpensesDTO>();

            foreach (var payer in payers)
            {
                payersDto.Add(new Payers_ExpensesDTO
                {

                    paidAmount = payer.paidAmount,
                    Share = payer.Share,
                    payerName=payer.payerName,
                    expense=payer.expense
                });
            }
            return payersDto;
           
        }

        public int UpdatePayersExpenses(Payers_Expenses payerExpense)
        {
            _context.payers_Expenses.Update(payerExpense);
            var result = _context.SaveChanges();
            return result;
            
        }

        public bool PayerExists(int id)
        {
            var payer = _context.payers_Expenses.Find(id);
            if (payer == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
