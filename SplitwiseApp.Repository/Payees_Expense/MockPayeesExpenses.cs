using SplitwiseApp.DomainModels.Models;
using SplitwiseApp.Repository.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SplitwiseApp.Repository.Payees_Expense
{
    public class MockPayeesExpenses : IPayeeExpenses
    {
        public void AddPayeesExpenses(Payees_Expenses payeesExpense)
        {
            throw new NotImplementedException();
        }

        public void DeletePayeesExpenses(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Payees_ExpensesDTO>> GetPayeesExpenses(int expenseId)
        {
            throw new NotImplementedException();
        }

        public void UpdatePayeesExpenses(Payees_Expenses payeesExpense)
        {
            throw new NotImplementedException();
        }
    }
}
