using Microsoft.VisualStudio.TestTools.UnitTesting;
using SplitwiseApp.DomainModels.Models;
using SplitwiseApp.Repository.DTOs;
using SplitwiseApp.Repository.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace SplitwiseApp.Repository.Test.Modules.User
{
    [TestClass]
    public class UserRepositoryTest
    {
        MockUser u = new MockUser();

        [TestMethod]
        public void AddingUserTest()
        {

            ApplicationUser addUser = new ApplicationUser();
            Assert.ThrowsExceptionAsync<NotImplementedException>(() => u.AddUser(addUser));

        }

        [TestMethod]

        public void UpdateUserTest()
        {

            ApplicationUser updateUser = new ApplicationUser();
            Assert.ThrowsExceptionAsync<NotImplementedException>(() => u.UpdateProfile(updateUser));

        }

     

        [TestMethod]

        public void GetUserTest()
        {
            Assert.ThrowsExceptionAsync<NotImplementedException>(() => u.GetUser());

        }

        [TestMethod]

        public void GetUserByIdTest()
        {
            Assert.ThrowsExceptionAsync<NotImplementedException>(() => u.GetUserById("1"));

        }

        [TestMethod]

        public void LoginTest()
        {
            UserDTO login = new UserDTO();
            Assert.ThrowsExceptionAsync<NotImplementedException>(() => u.Login(login));

        }
    }
}
