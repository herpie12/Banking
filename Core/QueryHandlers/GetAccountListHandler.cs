using Account.Core.Models;
using Account.Core.Queries;
using Account.Infrastructure.Repository;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Account.Core.QueryHandlers
{
    public class GetAccountListHandler : IRequestHandler<GetAccountListQuery, List<AccountModel>>
    {
        private readonly AccountRepository _accountRepository;
        public GetAccountListHandler(AccountRepository accountRepository)
        {
            _accountRepository = _accountRepository;
        }
        public Task<List<AccountModel>> Handle(GetAccountListQuery request, CancellationToken cancellationToken)
        {
            var test = new List<AccountModel>();

            return Task.FromResult(test);
           // return Task.FromResult(_accountRepository.GetAccounts());
        }
    }
}
