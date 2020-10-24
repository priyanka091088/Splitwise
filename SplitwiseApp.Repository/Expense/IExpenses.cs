using SplitwiseApp.DomainModels.Models;
using SplitwiseApp.Repository.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SplitwiseApp.Repository.Expense
{
    public interface IExpenses
    {
        Task<IEnumerable<ExpensesDTO>> GetExpenseForGroup(int groupId);
        Task<ExpensesDTO> GetExpensesById(int id);
        public Task AddAnExpense(Expenses expenses);
        public Task UpdateAParticularExpense(Expenses expenses);
        public Task DeleteAnExpense(int id);
        public bool ExpenseExist(int expenseId);
    }
}
