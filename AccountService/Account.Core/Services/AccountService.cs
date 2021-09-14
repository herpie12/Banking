using Account.Core.Models;
using Account.Domain.Interfaces;
using Account.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<int> CreateAccount(AccountDto bankAccount)
        {
            var newBankAccount = new BankAccount(bankAccount.AccountNo, bankAccount.AccountType, ParseEnum(bankAccount.Status), bankAccount.Balance, DateTime.Now);

            return await _accountRepository.CreateAccount(newBankAccount);
        }

        public async Task<IEnumerable<AccountDto>> GetAccounts()
        {
           var bankAccountList = await _accountRepository.GetAccounts();
           //TODO use automapper
           var accountModelList= bankAccountList.Select(z => new AccountDto { AccountNo = z.AccountNo, Status = z.Status.ToString(), AccountType = z.AccountType, Balance = z.Balance });

            return accountModelList;
        }

        public static AccountStatus ParseEnum(string value)
        {
            return (AccountStatus)Enum.Parse(typeof(AccountStatus), value, true);
        }
    }
}
