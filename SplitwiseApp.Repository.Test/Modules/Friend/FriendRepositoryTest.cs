using Microsoft.VisualStudio.TestTools.UnitTesting;
using SplitwiseApp.DomainModels.Models;
using SplitwiseApp.Repository.Friend;
using System;
using System.Collections.Generic;
using System.Text;

namespace SplitwiseApp.Repository.Test.Modules.Friend
{
    [TestClass]
    public class FriendRepositoryTest
    {
        MockFriends f = new MockFriends();

        [TestMethod]
        public void AddinFriendTest()
        {

            Friends addFriend = new Friends();
            Assert.ThrowsExceptionAsync<NotImplementedException>(() => f.AddAFriend(addFriend));

        }

        [TestMethod]

        public void UpdatingFriendTest()
        {

            Friends updateFriend = new Friends();
            Assert.ThrowsExceptionAsync<NotImplementedException>(() => f.UpdateAFriend(updateFriend));

        }

        [TestMethod]

        public void DeletingFriendTest()
        {
            Assert.ThrowsExceptionAsync<NotImplementedException>(() => f.DeleteAFriend(1));

        }

        [TestMethod]

        public void GetFriendTest()
        {
            Assert.ThrowsExceptionAsync<NotImplementedException>(() => f.GetFriends("1"));

        } 
    }
}
