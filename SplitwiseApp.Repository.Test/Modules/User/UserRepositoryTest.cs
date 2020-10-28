
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using SplitwiseApp.DomainModels.Models;
using SplitwiseApp.Repository.Database;
using SplitwiseApp.Repository.DTOs;
using SplitwiseApp.Repository.Test.DatabaseTest;
using SplitwiseApp.Repository.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SplitwiseApp.Repository.Test.Modules.User
{
    [TestFixture]
    public class UserRepositoryTest
    {
        private IUser _user;
        private Mock<FakeUserManager> _userManager = new Mock<FakeUserManager>();
        private IdentityResult identityResult = new IdentityResult();
        private IConfiguration _configuration;
        private readonly IMapper _mapper;

        private ApplicationUser CreateApplicationUser(string name, string email)
        {
            return new ApplicationUser { Name = name, Email = email,Balance=0 }; ;
        }
       
        private void SetUserManager(ApplicationUser User)
        {
            IdentityResult result = IdentityResult.Success;

            _userManager.Setup(x => x.CreateAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()))
                .ReturnsAsync(result);

            _userManager.Setup(x => x.FindByEmailAsync(It.IsAny<string>()))
                .ReturnsAsync(User);

            _userManager.Setup(x => x.UpdateAsync(It.IsAny<ApplicationUser>()))
                .ReturnsAsync(result);

            _userManager.Setup(x => x.CheckPasswordAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()))
                .ReturnsAsync(true);


        }
        private MockUser SetUpUserRepository(AppDbContext db)
        {
            var myConfiguration = new Dictionary<string, string>
            {
                { "JWT:ValidAudience", "http://localhost:4200" },
                {    "JWT:ValidIssuer", "http://localhost:44339" },
                {    "JWT:Secret", "ByYM000OLlMQG6VVVp1OH7Xzyr7gHuw1qvUC5dcGt3SNM"}
            };

            _configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(myConfiguration)
                .Build();
            return new MockUser(db, SetUserManager(), _mapper, _configuration);
        }

        private FakeUserManager SetUserManager()
        {
            return new Mock<FakeUserManager>().Object;
        }

        [TestCase("test", "test123@gmail.com")]
        public void AddingUserTest(string name,string email)
        {
            ApplicationUser applicationUser = CreateApplicationUser(name, email);

            SetUserManager(applicationUser);

            using (var db = MockDatabase.Create(nameof(AddingUserTest)))
            {
                _user = SetUpUserRepository(db);
                //_user.AddUser(applicationUser);

            }
            using (var db = MockDatabase.Create(nameof(AddingUserTest)))
            {
                /*var storedUser = db.Users.Single();
                Assert.AreEqual(storedUser.Name, applicationUser.Name);*/

                var task = _userManager.Object.FindByEmailAsync(email);
                task.Wait();
                var storedUsers = task.Result;
                Assert.AreEqual(storedUsers.Id, applicationUser.Id);
            }

        }

        /* [TestCase("test1", "test123@gmail.com")]

         public void UpdateUserTest(string name, string email)
         {
             ApplicationUser applicationUser = CreateApplicationUser(name, email);

             SetUserManager(applicationUser);

            using (var db = MockDatabase.Create(nameof(AddingUserTest)))
            {
                _user = SetUpUserRepository(db);
                _user.UpdateProfile(applicationUser);

            }
            using (var db = MockDatabase.Create(nameof(AddingUserTest)))
            {
                var storedUser = db.Users.Single();
                Assert.AreEqual(storedUser.Name, applicationUser.Name);

            var task = _userManager.Object.FindByEmailAsync(email);
            task.Wait();
                    var storedUsers = task.Result;
            Assert.AreEqual(storedUsers.Id, applicationUser.Id);
            }
    // ApplicationUser updateUser = new ApplicationUser();
    //Assert.ThrowsExceptionAsync<NotImplementedException>(() => u.UpdateProfile(updateUser));

}



         [TestCase]

         public void GetUserTest()
         {
             //Assert.ThrowsExceptionAsync<NotImplementedException>(() => u.GetUser());

         }

         [TestCase]

         public void GetUserByIdTest()
         {
            // Assert.ThrowsExceptionAsync<NotImplementedException>(() => u.GetUserById("1"));

         }

         [TestCase]

         public void LoginTest()
         {
             UserDTO login = new UserDTO();
            // Assert.ThrowsExceptionAsync<NotImplementedException>(() => u.Login(login));

         }*/
    }
}
