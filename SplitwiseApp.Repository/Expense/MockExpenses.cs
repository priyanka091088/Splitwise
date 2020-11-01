using Microsoft.EntityFrameworkCore;
using SplitwiseApp.DomainModels.Models;
using SplitwiseApp.Repository.DTOs;
using SplitwiseApp.Repository.Payees_Expense;
using SplitwiseApp.Repository.Payers_Expense;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitwiseApp.Repository.Expense
{
    public class MockExpenses : IExpenses
    {
        #region private variables
        private readonly AppDbContext _context;
        private readonly IPayersExpenses _payersExpenses;
        private readonly IPayeeExpenses _payeesExpenses;
        #endregion

        #region constructor
        public MockExpenses()
        {
                
        }
        public MockExpenses(AppDbContext context,IPayeeExpenses payeesExpenses,IPayersExpenses payersExpenses)
        {
            _context = context;
            _payersExpenses = payersExpenses;
            _payeesExpenses = payeesExpenses;
        }

        #endregion

        #region public methods
        public int AddAnExpense(Expenses expenses)
        {
            
            _context.expenses.Add(expenses);
            var result = _context.SaveChanges();
            return result;
            
        }

        public int DeleteAnExpense(int id)
        {
            var expenseDel = _context.expenses.Find(id);
            _context.expenses.Remove(expenseDel);
            var result=_context.SaveChanges();
            return result;
        }

        public bool ExpenseExist(int expenseId)
        {
            return _context.expenses.Any(e => e.expenseId == expenseId);
        }

        public IEnumerable<ExpensesDTO> GetExpenseForGroup(int groupId)
        {
            var expense = _context.expenses.Where(e => e.groupId == groupId);

            List<ExpensesDTO> groupExpenses = new List<ExpensesDTO>();

            foreach(var exp in expense)
            {
                groupExpenses.Add(new ExpensesDTO
                {
                    Description = exp.Description
                });
            }
            return groupExpenses.ToList();
            
        }

        public IEnumerable<ExpensesDTO> GetExpensesByexpenseId(int expenseId)
        {
            var expense = _context.expenses.Include(e => e.users).Where(e => e.expenseId == expenseId);


            List<ExpensesDTO> expenses = new List<ExpensesDTO>();
            foreach (var exp in expense)
            {
                expenses.Add(new ExpensesDTO
                {

                    Description = exp.Description,
                    Amount = exp.Amount,
                    Currency=exp.Currency,
                    creatorId = exp.users.Name
                });
            }
            return expenses.ToList();
        }

        public int UpdateAParticularExpense(Expenses expenses)
        {
            _context.expenses.Update(expenses);
            var result = _context.SaveChanges();
            return result;
            
        }
        #endregion
    }
}
