using Account.Core.Models;
using MediatR;

namespace Account.Core.Commands
{
    public class CreateAccountCommand : IRequest<int>
    {
        public AccountDto _accountDto;
        public CreateAccountCommand(AccountDto accountDto)
        {
            _accountDto = accountDto;
        }
    }
}
