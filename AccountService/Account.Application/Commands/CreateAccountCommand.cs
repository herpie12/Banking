using Account.Application.DtoModels;
using MediatR;
using System.Threading;

namespace Account.Application.Commands
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
