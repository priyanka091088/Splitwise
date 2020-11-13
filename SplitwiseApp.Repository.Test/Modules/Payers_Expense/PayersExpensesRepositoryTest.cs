using Microsoft.VisualStudio.TestTools.UnitTesting;
using SplitwiseApp.DomainModels.Models;
using SplitwiseApp.Repository.Payers_Expense;
using System;
using System.Collections.Generic;
using System.Text;

namespace SplitwiseApp.Repository.Test.Modules.Payers_Expense
{
    [TestClass]
    public class PayersExpensesRepositoryTest
    {
        PayersExpensesRepository payer = new PayersExpensesRepository();

        [TestMethod]
        public void AddingPayersExpenseTest()
        {

            Payers_Expenses addPayerExpense = new Payers_Expenses();
            //Assert.ThrowsExceptionAsync<NotImplementedException>(() => payer.AddPayersExpenses(addPayerExpense));

        }

        [TestMethod]

        public void UpdatingPayersExpenseTest()
        {

            Payers_Expenses updatePayerExpense = new Payers_Expenses();
           // Assert.ThrowsExceptionAsync<NotImplementedException>(() => payer.UpdatePayersExpenses(updatePayerExpense));

        }

        [TestMethod]

        public void DeletingPayersExpenseTest()
        {
           // Assert.ThrowsExceptionAsync<NotImplementedException>(() => payer.DeletePayersExpenses(1));

        }

        [TestMethod]

        public void GetPayersExpensesTest()
        {
           // Assert.ThrowsExceptionAsync<NotImplementedException>(() => payer.GetPayersExpenses(1));

        }
    }
}
