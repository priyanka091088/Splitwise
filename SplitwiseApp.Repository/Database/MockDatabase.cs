using Microsoft.EntityFrameworkCore;
using SplitwiseApp.DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SplitwiseApp.Repository.Database
{
    public class MockDatabase
    {
        public static AppDbContext Create(string databaseName)
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(nameof(databaseName))
                .Options;
            return new AppDbContext(options);
        }
    }
}
