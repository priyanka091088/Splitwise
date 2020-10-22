using SplitwiseApp.Repository.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SplitwiseApp.Repository.Payees_Expenses
{
    public class MockPayeesExpenses : IPayeeExpenses
    {
        public Task<Payees_ExpensesDTO> AddPayeesExpenses(Payers_ExpensesDTO payerExpense)
        {
            throw new NotImplementedException();
        }

        public Task<Payees_ExpensesDTO> DeletePayeesExpenses(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Payees_ExpensesDTO> GetPayeesExpenses(int expenseId)
        {
            throw new NotImplementedException();
        }

        public Task<Payees_ExpensesDTO> UpdatePayeesExpenses(Payees_ExpensesDTO payerExpense)
        {
            throw new NotImplementedException();
        }
    }
}
