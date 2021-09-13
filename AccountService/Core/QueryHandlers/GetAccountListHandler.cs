using Account.Core.Models;
using Account.Core.Queries;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Account.Core.QueryHandlers
{
    public class GetAccountListHandler : IRequestHandler<GetAccountListQuery, IEnumerable<AccountDto>>
    {
        private readonly IAccountService _accountService;
        public GetAccountListHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }
        public async Task<IEnumerable<AccountDto>> Handle(GetAccountListQuery request, CancellationToken cancellationToken)
        {
            return await _accountService.GetAccounts(); 
        }
    }
}
