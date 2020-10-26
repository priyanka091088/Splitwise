using NUnit.Framework;
using SplitwiseApp.DomainModels.Models;
using SplitwiseApp.Repository.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SplitwiseApp.Repository.Test.DatabaseTest
{
    [TestFixture]
    public class databaseTest
    {
        [SetUp]
        public void SetUp()
        {
        }

        [TestCase("test", "test@gmail.com")]
        public void TestDatabase(string name, string email)
        {
            ApplicationUser sampleGroup = new ApplicationUser { Name = name,UserName=email};
            using (var db = MockDatabase.Create(nameof(TestDatabase)))
            {
                db.Users.Add(sampleGroup);
                db.SaveChanges();
            }
            using (var db = MockDatabase.Create(nameof(TestDatabase)))
            {
                var savedUser = db.Users.Single();
                Assert.AreEqual(sampleGroup.Name, savedUser.Name);
            }

        }
    }
}
