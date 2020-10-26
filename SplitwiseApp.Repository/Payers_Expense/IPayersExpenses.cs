﻿using SplitwiseApp.DomainModels.Models;
using SplitwiseApp.Repository.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SplitwiseApp.Repository.Payers_Expense
{
    public interface IPayersExpenses
    {
        Task<IEnumerable<Payers_ExpensesDTO>> GetPayersExpenses(int expenseId);
        public Task AddPayersExpenses(Payers_Expenses payerExpense);
        public Task UpdatePayersExpenses(Payers_Expenses payerExpense);
        public Task DeletePayersExpenses(int id);
    }
}