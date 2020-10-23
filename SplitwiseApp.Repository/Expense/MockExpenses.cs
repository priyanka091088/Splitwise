using SplitwiseApp.DomainModels.Models;
using SplitwiseApp.Repository.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SplitwiseApp.Repository.Expense
{
    public class MockExpenses : IExpenses
    {
        public void AddAnExpense(Expenses expenses)
        {
            //Also call the payers_Expenses and Payees_Expenses post method
            throw new NotImplementedException();
        }

        public void DeleteAnExpense(int id)
        {
            //Also call the payers_expenses and payees_expenses delete method
            throw new NotImplementedException();
        }

        public bool ExpenseExist(int expenseId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ExpensesDTO>> GetExpenseForGroup(int groupId)
        {
            throw new NotImplementedException();
        }

        public Task<ExpensesDTO> GetExpensesById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateAParticularExpense(Expenses expenses)
        {
            //Also call the payers_expenses and payees_expenses update method if necessary
            throw new NotImplementedException();
        }
    }
}
