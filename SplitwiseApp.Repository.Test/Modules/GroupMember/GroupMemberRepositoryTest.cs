using Microsoft.VisualStudio.TestTools.UnitTesting;
using SplitwiseApp.DomainModels.Models;
using SplitwiseApp.Repository.GroupMember;
using System;
using System.Collections.Generic;
using System.Text;

namespace SplitwiseApp.Repository.Test.Modules.GroupMember
{
    [TestClass]
    public class GroupMemberRepositoryTest
    {
        MockGroupMembers m = new MockGroupMembers();
        [TestMethod]
        public void AddingMemberTest()
        {

            GroupMembers addMember = new GroupMembers();
            //Assert.ThrowsExceptionAsync<NotImplementedException>(() => m.AddGroupMembers(addMember));

        }

        [TestMethod]

        public void UpdatingExpenseTest()
        {

            GroupMembers updateMember = new GroupMembers();
           // Assert.ThrowsExceptionAsync<NotImplementedException>(() => m.UpdateGroupMembers(updateMember));

        }

        [TestMethod]

        public void DeletingExpense()
        {
           // Assert.ThrowsExceptionAsync<NotImplementedException>(() => m.DeleteGroupMembers(1));

        }

        [TestMethod]

        public void GetExpensesForGroupTest()
        {
           // Assert.ThrowsExceptionAsync<NotImplementedException>(() => m.GetGroupMembers(1));

        }
    }
}
