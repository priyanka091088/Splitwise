using Microsoft.VisualStudio.TestTools.UnitTesting;
using SplitwiseApp.DomainModels.Models;
using SplitwiseApp.Repository.Group;
using System;
using System.Collections.Generic;
using System.Text;

namespace SplitwiseApp.Repository.Test.Modules.Group
{
    [TestClass]
    public class GroupRepositoryTest
    {
        GroupsRepository g = new GroupsRepository();

        [TestMethod]
        public void AddingGroupTest()
        {

            Groups addGroup = new Groups();
           //ssert.ThrowsExceptionAsync<NotImplementedException>(() => g.AddGroupForUser(addGroup));

        }

        [TestMethod]

        public void UpdatingAGroupTest()
        {

            Groups updateGroup = new Groups();
           //ssert.ThrowsExceptionAsync<NotImplementedException>(() => g.UpdateAGroup(updateGroup));

        }

        [TestMethod]

        public void DeletingAGroupTest()
        {
           //ssert.ThrowsExceptionAsync<NotImplementedException>(() => g.DeleteAGroupById(1));

        }

        [TestMethod]

        public void GetGroupByIdTest()
        {
           //ssert.ThrowsExceptionAsync<NotImplementedException>(() => g.GetGroupByGroupId(1));

        }

        [TestMethod]

        public void GetExpenseByUserIdTest()
        {
           // Assert.ThrowsExceptionAsync<NotImplementedException>(() => g.GetGroupByUserId("1"));

        }
    }
}
