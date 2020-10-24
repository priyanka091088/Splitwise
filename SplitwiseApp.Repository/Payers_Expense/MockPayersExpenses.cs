using SplitwiseApp.DomainModels.Models;
using SplitwiseApp.Repository.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SplitwiseApp.Repository.Payers_Expense
{
    public class MockPayersExpenses : IPayersExpenses
    {
        public Task AddPayersExpenses(Payers_Expenses payerExpense)
        {
            throw new NotImplementedException();
        }

        public Task DeletePayersExpenses(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Payers_ExpensesDTO>> GetPayersExpenses(int expenseId)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePayersExpenses(Payers_Expenses payerExpense)
        {
            throw new NotImplementedException();
        }
    }
}
