using SplitwiseApp.Repository.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SplitwiseApp.Repository.Payers_Expenses
{
    public interface IPayersExpenses
    {
        Task<Payers_ExpensesDTO> GetPayersExpenses(int expenseId);
        Task<Payers_ExpensesDTO> AddPayersExpenses(Payers_ExpensesDTO payerExpense);
        Task<Payers_ExpensesDTO> UpdatePayersExpenses(Payers_ExpensesDTO payerExpense);
        Task<Payers_ExpensesDTO> DeletePayersExpenses(int id);
    }
}
