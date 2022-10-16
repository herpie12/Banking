using Account.Domain.Interfaces;
using Account.Domain.Models;
using Account.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Account.Infrastructure.Repositories
{
    public class BankAccountRepository : IBankAccountRepository
    {
        private readonly BankAccountDbContext _bankAccountDbContext;

        public BankAccountRepository(BankAccountDbContext bankAccountDbContext)
        {
            _bankAccountDbContext = bankAccountDbContext;
        }
        public async Task<int> CreateAccount(BankAccount bankAccount)
        {
            using (var transaction = _bankAccountDbContext.Database.BeginTransaction())
            {
                try
                {
                    _bankAccountDbContext.Accounts.Add(bankAccount);

                    _bankAccountDbContext.AccountOuterBoxMessages.Add(new AccountOuterBoxMessage
                    { Id = new System.Guid(), OccurredOnUtc = System.DateTime.UtcNow, Content = JsonSerializer.Serialize<BankAccount>(bankAccount) });

                    await _bankAccountDbContext.SaveChangesAsync();

                    await transaction.CommitAsync();

                    return 0;
                }
                catch (System.Exception)
                {
                    transaction.Rollback();

                    throw;
                }
            }
        }

        public async Task<IEnumerable<BankAccount>> GetAccounts()
        {
            var bankAccounts = await _bankAccountDbContext.Accounts.ToListAsync();

            return bankAccounts;
        }

        public async Task<int> Save()
        {
            return await _bankAccountDbContext.SaveChangesAsync();
        }

        public async Task<decimal> Withdraw(decimal amount, int accountId)
        {
            var bankAccount = _bankAccountDbContext.Accounts.Where(z => z.Id == accountId).First();

            var newBalance = bankAccount.WithdrawAmount(amount);
            _bankAccountDbContext.Entry(bankAccount).State = EntityState.Modified;

            await _bankAccountDbContext.SaveChangesAsync();

            return newBalance;
        }
    }
}
