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
        IEnumerable<Payees_ExpensesDTO> GetPayeesExpensesByExpenseId(int expenseId);
        public int AddPayeesExpenses(Payees_Expenses payerExpense);
        public int UpdatePayeesExpenses(Payees_Expenses payerExpense);
        public int DeletePayeesExpenses(int id);
        public bool PayeeExists(int id);
    }
}
