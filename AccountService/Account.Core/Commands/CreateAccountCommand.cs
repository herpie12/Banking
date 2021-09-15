using Account.Core.Models;
using MediatR;

namespace Account.Core.Commands
{
    public class CreateAccountCommand : IRequest<int>
    {
        public AccountDto AccountDto;
        public CreateAccountCommand(AccountDto accountDto)
        {
            AccountDto = accountDto;
        }
    }
}
