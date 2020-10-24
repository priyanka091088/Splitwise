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
        MockGroups g = new MockGroups();

        [TestMethod]
        public void AddingGroupTest()
        {

            Groups addGroup = new Groups();
            Assert.ThrowsExceptionAsync<NotImplementedException>(() => g.AddGroupForUser(addGroup));

        }

        [TestMethod]

        public void UpdatingAGroupTest()
        {

            Groups updateGroup = new Groups();
            Assert.ThrowsExceptionAsync<NotImplementedException>(() => g.UpdateAGroup(updateGroup));

        }

        [TestMethod]

        public void DeletingAGroupTest()
        {
            Assert.ThrowsExceptionAsync<NotImplementedException>(() => g.DeleteAGroupById(1));

        }

        [TestMethod]

        public void GetGroupByIdTest()
        {
            Assert.ThrowsExceptionAsync<NotImplementedException>(() => g.GetGroupByGroupId(1));

        }

        [TestMethod]

        public void GetExpenseByUserIdTest()
        {
            Assert.ThrowsExceptionAsync<NotImplementedException>(() => g.GetGroupByUserId("1"));

        }
    }
}
