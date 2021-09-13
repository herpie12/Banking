using Account.Domain.Interfaces;
using Account.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Account.Infrastructure.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AccountDbContext _accountDbContext;
        public AccountRepository(AccountDbContext accountDbContext)
        {
            _accountDbContext = accountDbContext;
        }
        public Task<IEnumerable<Domain.Models.Account>> CreateAccount()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Domain.Models.Account>> Delete()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Domain.Models.Account> GetAccounts()
        {
            return _accountDbContext.Accounts;
        }
    }
}
