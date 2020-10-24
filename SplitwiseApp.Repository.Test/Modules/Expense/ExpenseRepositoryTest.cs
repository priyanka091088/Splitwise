using Microsoft.VisualStudio.TestTools.UnitTesting;
using SplitwiseApp.DomainModels.Models;
using SplitwiseApp.Repository.Expense;

using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SplitwiseApp.Repository.Test.Modules.Expense
{
    [TestClass]
    public class ExpenseRepositoryTest
    {
        MockExpenses e = new MockExpenses();
        [TestMethod]
        public void AddingExpenseTest()
        {
            
            Expenses addExpense = new Expenses();
            Assert.ThrowsExceptionAsync<NotImplementedException>(() => e.AddAnExpense(addExpense));
            
        }

        [TestMethod]
        
        public void UpdatingExpenseTest()
        {

            Expenses updateExpense = new Expenses();
            Assert.ThrowsExceptionAsync<NotImplementedException>(() => e.UpdateAParticularExpense(updateExpense));

        }

        [TestMethod]
       
        public void DeletingExpense()
        {
            Assert.ThrowsExceptionAsync<NotImplementedException>(() => e.DeleteAnExpense(1));

        }

        [TestMethod]
    
        public void GetExpensesForGroupTest()
        {
            Assert.ThrowsExceptionAsync<NotImplementedException>(() => e.GetExpenseForGroup(1));

        }

        [TestMethod]
      
        public void GetExpenseByIdTest()
        {
            Assert.ThrowsExceptionAsync<NotImplementedException>(() => e.GetExpensesById(1));

        }
    }
}
