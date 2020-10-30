using SplitwiseApp.DomainModels.Models;
using SplitwiseApp.Repository.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
namespace SplitwiseApp.Repository.Payees_Expense
{
    public class MockPayeesExpenses : IPayeeExpenses
    {
        #region private variable
        private readonly AppDbContext _context;
        #endregion

        #region constructor
        public MockPayeesExpenses()
        {

        }

        public MockPayeesExpenses(AppDbContext context)
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

        public IEnumerable<Payees_ExpensesDTO> GetPayeesExpensesByExpenseId(int expenseId)
        {
            var payees = from payee in _context.payees_Expenses
                         join expense in _context.expenses
                         on payee.expenseId equals expense.expenseId
                         where payee.expenseId == expenseId
                         select new Payees_ExpensesDTO
                         {
                             
                             Share = payee.Share,
                             payerName = payee.payer.Name,
                             receiverName=payee.receiever.Name,
                             expense = payee.expenses.Description
                         };
            List<Payees_ExpensesDTO> payeesDto = new List<Payees_ExpensesDTO>();

            foreach (var payee in payees)
            {
                payeesDto.Add(new Payees_ExpensesDTO
                {
                    Share = payee.Share,
                    payerName = payee.payerName,
                    receiverName=payee.receiverName,
                    expense=payee.expense
                });
            }
            return payeesDto;


            throw new NotImplementedException();
        }

        public bool PayeeExists(int id)
        {
            var payee = _context.payees_Expenses.Find(id);
            if (payee == null)
            {
                return false;
            }
            else
            {
                return true;
            }
           
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
