using Account.Domain.Interfaces;
using Account.Domain.Models;
using Account.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Account.Infrastructure.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly BankAccountDbContext _accountDbContext;

        public AccountRepository(BankAccountDbContext accountDbContext)
        {
            _accountDbContext = accountDbContext;
        }

        public Task<int> CreateAccount(BankAccount bankAccount)
        {
            _accountDbContext.Accounts.Add(new BankAccount(bankAccount.AccountNo, bankAccount.AccountType,
                bankAccount.Status, bankAccount.Balance, bankAccount.Created));

            return Task.FromResult(_accountDbContext.SaveChanges());
        }

        public Task<BankAccount> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<BankAccount>> GetAccounts()
        {
            return await _accountDbContext.Accounts.ToListAsync();
        }
    }
}
