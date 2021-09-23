using Account.Application.DtoModels;
using MediatR;

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
