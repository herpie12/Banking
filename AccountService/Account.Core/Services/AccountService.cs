using Account.Core.Models;
using Account.Domain.Models;
using Account.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

namespace Account.Core.Services
{
    public class AccountService : IAccountService
    {
        private readonly BankAccountDbContext _bankAccountDbContext;

        public AccountService(BankAccountDbContext bankAccountDbContext)
        {
            _bankAccountDbContext = bankAccountDbContext;
        }

        public async Task<int> CreateAccount(AccountDto bankAccount)
        {
            _bankAccountDbContext.Accounts.Add(new BankAccount(bankAccount.AccountNo, bankAccount.AccountType,
            bankAccount.Status, bankAccount.Balance, DateTime.Now));

            return await _bankAccountDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<AccountDto>> GetAccounts()
        {
            var bankAccounts = await _bankAccountDbContext.Accounts.ToListAsync();

            //TODO use automapper
            var accountModelList = bankAccounts.Select(z => new AccountDto { AccountNo = z.AccountNo, Status = z.Status, AccountType = z.AccountType, Balance = z.Balance });

            return accountModelList;
        }

        public async Task<decimal> Withdraw(decimal amount, int accountId)
        {
            var bankAccount = _bankAccountDbContext.Accounts.Where(z => z.Id == accountId).First();

            var newBalance = bankAccount.Withdraw(amount);

            _bankAccountDbContext.Entry(bankAccount).State = EntityState.Modified;

            await _bankAccountDbContext.SaveChangesAsync();

            return newBalance;
        }

        public static AccountStatus ParseEnum(string value)
        {
            return (AccountStatus)Enum.Parse(typeof(AccountStatus), value, true);
        }
    }
}
