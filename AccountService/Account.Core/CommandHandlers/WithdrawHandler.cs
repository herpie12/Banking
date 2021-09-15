using Account.Core.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Account.Core.CommandHandlers
{
    public class WithdrawHandler : IRequestHandler<WithdrawCommand, decimal>
    {
        private readonly IAccountService _accountService;

        public WithdrawHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<decimal> Handle(WithdrawCommand request, CancellationToken cancellationToken)
        {
           return await _accountService.Withdraw(request.Amount, request.AccountId);
        }
    }
}
