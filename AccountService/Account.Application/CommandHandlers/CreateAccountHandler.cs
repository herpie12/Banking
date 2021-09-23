using Account.Application.Commands;
using Account.Application.DtoModels;
using Account.Domain.Interfaces;
using Account.Domain.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace Account.Application.CommandHandlers
{
    public class CreateAccountHandler : IRequestHandler<CreateAccountCommand, int>
    {
        private readonly IBankAccountRepository _bankAccountRepository;

        public CreateAccountHandler(IBankAccountRepository bankAccountRepository)
        {
            _bankAccountRepository = bankAccountRepository;
        }

        public async Task<int> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            var accountSaved = await _bankAccountRepository.CreateAccount(Map(request.AccountDto));

            return accountSaved;
        }
        private BankAccount Map(AccountDto accountDto)
           => new BankAccount(accountDto.AccountNo, accountDto.AccountType, accountDto.Status, accountDto.Balance, DateTime.Now);

    }
}
