using Account.Core.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Account.Core.CommandHandlers
{
    public class CreateAccountHandler : IRequestHandler<CreateAccountCommand, int>
    {
        private readonly IAccountService _accountService;

        public CreateAccountHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<int> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            var accountSaved = await _accountService.CreateAccount(request.AccountDto);

            return accountSaved;
        }
    }
}
