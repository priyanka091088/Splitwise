using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SplitwiseApp.DomainModels.Models
{
    public class AppDbContext: IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Groups> group { get; set; }
        public DbSet<GroupMembers> groupMember { get; set; }
        public DbSet<Expenses> expenses { get; set; }
        public DbSet<Friends> friends { get; set; }
        public DbSet<Payers_Expenses> payers_Expenses { get; set; }
        public DbSet<Payees_Expenses> payees_Expenses { get; set; }
        public DbSet<Settlement> settlement { get; set; }
    }
}
