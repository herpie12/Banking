using Account.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Account.Infrastructure.Data.Context
{
    public class BankAccountDbContext : DbContext
    {
        public DbSet<BankAccount> Accounts { get; set; }
        public DbSet<AccountOuterBoxMessage> AccountOuterBoxMessages { get; set; }

        public BankAccountDbContext(DbContextOptions options) : base(options)
        {
            this.Database.EnsureCreated();
        }
    }
}
