using Microsoft.VisualStudio.TestTools.UnitTesting;
using SplitwiseApp.DomainModels.Models;
using SplitwiseApp.Repository.Payees_Expense;
using System;
using System.Collections.Generic;
using System.Text;

namespace SplitwiseApp.Repository.Test.Modules.Payees_Expense
{
    [TestClass]
    public class PayeesExpensesRepositoryTest
    {
        MockPayeesExpenses payee = new MockPayeesExpenses();

        [TestMethod]
        public void AddingPayeesExpenseTest()
        {

            Payees_Expenses payeeExpense = new Payees_Expenses();
            //Assert.ThrowsExceptionAsync<NotImplementedException>(() => payee.AddPayeesExpenses(payeeExpense));

        }

        [TestMethod]

        public void UpdatingAGroupTest()
        {

            Payees_Expenses updateExpense = new Payees_Expenses();
            //Assert.ThrowsExceptionAsync<NotImplementedException>(() => payee.UpdatePayeesExpenses(updateExpense));

        }

        [TestMethod]

        public void DeletingPayeeExpenseTest()
        {
           // Assert.ThrowsExceptionAsync<NotImplementedException>(() => payee.DeletePayeesExpenses(1));

        }

        [TestMethod]

        public void GetPayeesExpenseTest()
        {
           // Assert.ThrowsExceptionAsync<NotImplementedException>(() => payee.GetPayeesExpenses(1));

        }
    }
}
