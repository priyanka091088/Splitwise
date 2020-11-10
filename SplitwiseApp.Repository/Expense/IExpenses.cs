using Microsoft.AspNetCore.Mvc;
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
        IEnumerable<ExpensesDTO> GetExpenseForGroup(int groupId);
        ActionResult<ExpensesDTO> GetExpensesByexpenseId(int id);
        public ActionResult<Expenses> AddAnExpense(Expenses expenses);
        public int UpdateAParticularExpense(Expenses expenses);
        public int DeleteAnExpense(int id);
        public bool ExpenseExist(int expenseId);
    }
}
