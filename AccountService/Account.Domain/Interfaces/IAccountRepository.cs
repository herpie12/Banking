using Account.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Account.Domain.Interfaces
{
   public interface IAccountRepository
    {
        Task<IEnumerable<BankAccount>> GetAccounts();

        Task<BankAccount> Delete(int Id);

        Task <int> CreateAccount(BankAccount bankAccount);
    }
}
