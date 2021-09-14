using Account.Core.Models;
using Account.Domain.Interfaces;
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
        public async Task<IEnumerable<AccountDto>> GetAccounts()
        {
           var bankAccountList = await _accountRepository.GetAccounts();
           var accountModelList= bankAccountList.Select(z => new AccountDto { AccountNo = z.AccountNo, Status = z.Status, AccountType = z.AccountType, Balance = 1000.1m });

            return accountModelList;
        }
    }
}
