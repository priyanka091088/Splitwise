using SplitwiseApp.Repository.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SplitwiseApp.Repository.Payees_Expenses
{
    public interface IPayeeExpenses
    {
        Task<Payees_ExpensesDTO> GetPayeesExpenses(int expenseId);
        Task<Payees_ExpensesDTO> AddPayeesExpenses(Payers_ExpensesDTO payerExpense);
        Task<Payees_ExpensesDTO> UpdatePayeesExpenses(Payees_ExpensesDTO payerExpense);
        Task<Payees_ExpensesDTO> DeletePayeesExpenses(int id);
    }
}
