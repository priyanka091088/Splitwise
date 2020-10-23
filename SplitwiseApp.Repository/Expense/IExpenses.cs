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
        public void AddAnExpense(Expenses expenses);
        public void UpdateAParticularExpense(Expenses expenses);
        public void DeleteAnExpense(int id);
        public bool ExpenseExist(int expenseId);
    }
}
