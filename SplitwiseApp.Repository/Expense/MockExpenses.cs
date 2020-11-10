using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IMapper _mapper;
        private readonly IPayersExpenses _payersExpenses;
        private readonly IPayeeExpenses _payeesExpenses;
        #endregion

        #region constructor
        public MockExpenses()
        {
                
        }
        public MockExpenses(AppDbContext context,IPayeeExpenses payeesExpenses,IPayersExpenses payersExpenses,IMapper mapper)
        {
            _context = context;
            _payersExpenses = payersExpenses;
            _payeesExpenses = payeesExpenses;
            _mapper = mapper;
        }

        #endregion

        #region public methods
        public ActionResult<Expenses> AddAnExpense(Expenses expenses)
        {
            
            _context.expenses.Add(expenses);
            _context.SaveChanges();
            return expenses;
            
        }

        public int DeleteAnExpense(int id)
        {
            //removing the particular expense
            var expenseDel = _context.expenses.Find(id);
            _context.expenses.Remove(expenseDel);

            //removing the payers of that particular expense
            IEnumerable<Payers_Expenses> payer = _context.payers_Expenses.Where(p => p.expenseId == id);
            _context.payers_Expenses.RemoveRange(payer);

            //removing the payees of that particular expense
            IEnumerable<Payees_Expenses> payee = _context.payees_Expenses.Where(pa => pa.expenseId == id);
            _context.payees_Expenses.RemoveRange(payee);

            //removing the payees of that particular expense
            IEnumerable<Settlement> settle = _context.settlement.Where(s => s.expenseId == id);
            _context.settlement.RemoveRange(settle);

            var result = _context.SaveChanges();
            return result;
        }

        public bool ExpenseExist(int expenseId)
        {
            var expense = _context.expenses.FirstOrDefault(e=>e.expenseId==expenseId);
            if (expense == null)
            {
                return false;
            }
            else
            {
                return true;
            }
            
        }

        public IEnumerable<ExpensesDTO> GetExpenseForGroup(int groupId)
        {
            var expense = _context.expenses.Where(e => e.groupId == groupId);


            return expense.Select(e => new ExpensesDTO
            {
                expenseId = e.expenseId,
                Description = e.Description,
                Amount = e.Amount,
                SplitBy = e.SplitBy
            });
            
        }

        public ActionResult<ExpensesDTO> GetExpensesByexpenseId(int expenseId)
        {
            return _mapper.Map<ExpensesDTO>(_context.expenses.Include(u => u.users).FirstOrDefault(e => e.expenseId == expenseId));
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
