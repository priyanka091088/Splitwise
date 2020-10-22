using SplitwiseApp.Repository.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SplitwiseApp.Repository.Expenses
{
    public interface IExpenses
    {
        Task<IEnumerable<ExpensesDTO>> GetExpenseForGroup(int groupId);
        Task<ExpensesDTO> GetExpensesById(int id);
        Task<ExpensesDTO> AddAnExpense(ExpensesDTO expenses);
        Task<ExpensesDTO> UpdateAParticularExpense(ExpensesDTO expenses);
        Task<ExpensesDTO> DeleteAnExpense(int id);
    }
}
