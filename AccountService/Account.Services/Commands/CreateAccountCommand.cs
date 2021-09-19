using Account.Services.DtoModels;
using MediatR;

namespace Account.Services.Commands
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
