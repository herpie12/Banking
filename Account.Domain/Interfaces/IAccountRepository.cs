using System.Collections.Generic;
using System.Threading.Tasks;

namespace Account.Domain.Interfaces
{
   public interface IAccountRepository
    {
        IEnumerable<Models.Account> GetAccounts();

        Task<IEnumerable<Models.Account>> Delete();

        Task<IEnumerable<Models.Account>> CreateAccount();
    }
}
