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

        public Task<bool> CreateAccount(BankAccount bankAccount)
        {
            throw new NotImplementedException();
        }

        public Task<BankAccount> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<BankAccount>> GetAccounts()
        {
            //Testing endpoint HttpGet, test object creation
            _accountDbContext.Accounts.Add(new BankAccount { AccountNo = 132456, Created = DateTime.Now, AccountType = "Shared", Status = "Personal Account" });
            _accountDbContext.SaveChanges();

            return await _accountDbContext.Accounts.ToListAsync();
        }
    }
}
