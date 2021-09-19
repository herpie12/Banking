using Account.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Account.Domain.Interfaces
{
    public interface IBankAccountRepository
    {
        Task<IEnumerable<BankAccount>> GetAccounts();

        Task<int> CreateAccount(BankAccount accountDto);

        Task<decimal> Withdraw(decimal amount, int accountId);

        Task<int> Save();
    }
}
