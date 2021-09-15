using Account.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Account.Core
{
   public interface IAccountService
    {
        Task<IEnumerable<AccountDto>> GetAccounts();

        Task<int> CreateAccount(AccountDto accountDto);

        Task<decimal> Withdraw(decimal amount, int accountId);
    }
}
