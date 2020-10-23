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
        public void AddPayersExpenses(Payers_Expenses payerExpense)
        {
            throw new NotImplementedException();
        }

        public void DeletePayersExpenses(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Payers_ExpensesDTO>> GetPayersExpenses(int expenseId)
        {
            throw new NotImplementedException();
        }

        public void UpdatePayersExpenses(Payers_Expenses payerExpense)
        {
            throw new NotImplementedException();
        }
    }
}
