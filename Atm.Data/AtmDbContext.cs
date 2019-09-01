using Atm.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Atm.Data
{
    public class DbContextFactory : IDesignTimeDbContextFactory<AtmDbContext>
    {
        public AtmDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AtmDbContext>();
            optionsBuilder.UseSqlServer("Server=TRC-LAPTOP\\SQLEXPRESS;Database=ATM;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new AtmDbContext(optionsBuilder.Options);
        }
    }

    public class AtmDbContext : DbContext
    {
        public AtmDbContext(DbContextOptions options)
            : base(options) { }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Withdrawal> Withdrawal { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Withdrawal>()
               .HasOne(x => x.Account)
               .WithMany(x => x.Withdrawals);
        }

        public DbSet<T> DbSet<T>() where T : class
        {
            return Set<T>();
        }
    }
}
