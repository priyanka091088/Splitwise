using SplitwiseApp.DomainModels.Models;
using SplitwiseApp.Repository.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SplitwiseApp.Repository.Payers_Expense
{
    public interface IPayersExpenses
    {
        IEnumerable<Payers_ExpensesDTO> GetPayersExpensesByExpenseId(int expenseId);
        IEnumerable<Payers_ExpensesDTO> GetPayersByUserId(string userId);
        public int AddPayersExpenses(Payers_Expenses payerExpense);
        public int UpdatePayersExpenses(Payers_Expenses payerExpense);
        public int DeletePayersExpenses(int id);
        bool PayerExists(int id);
    }
}
