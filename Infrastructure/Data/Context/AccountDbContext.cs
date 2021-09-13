using Microsoft.EntityFrameworkCore;

namespace Account.Infrastructure.Data.Context
{
    public class AccountDbContext : DbContext
    {
        public DbSet<Domain.Models.Account> Accounts { get; set; }
        public AccountDbContext(DbContextOptions options) : base(options)
        {
        }

    }
}
