using SplitwiseApp.DomainModels.Models;
using SplitwiseApp.Repository.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SplitwiseApp.Repository.Payees_Expense
{
    public interface IPayeeExpenses
    {
        Task<IEnumerable<Payees_ExpensesDTO>> GetPayeesExpenses(int expenseId);
        public void AddPayeesExpenses(Payees_Expenses payerExpense);
        public void UpdatePayeesExpenses(Payees_Expenses payerExpense);
        public void DeletePayeesExpenses(int id);
    }
}
