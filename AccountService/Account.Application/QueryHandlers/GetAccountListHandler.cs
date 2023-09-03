using Account.Application.DtoModels;
using Account.Application.Queries;
using Account.Domain.Interfaces;
using Account.Domain.Models;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Account.Application.QueryHandlers
{
    public class GetAccountListHandler : IRequestHandler<GetAccountListQuery, IEnumerable<AccountDto>>
    {
        private readonly IBankAccountRepository _bankAccountRepository;
        public GetAccountListHandler(IBankAccountRepository bankAccountRepository)
        {
            _bankAccountRepository = bankAccountRepository;
        }
        public async Task<IEnumerable<AccountDto>> Handle(GetAccountListQuery request, CancellationToken cancellationToken)
        {
            await Task.Delay(10_000, cancellationToken);

            var banckAccounts = await _bankAccountRepository.GetAccounts();
            return banckAccounts.Select(x => Map(x));
        }

        private AccountDto Map(BankAccount bankAccount)
        => new AccountDto
        {
            AccountNo = bankAccount.AccountNo,
            AccountType = bankAccount.AccountType,
            Balance = bankAccount.Balance,
            Status = bankAccount.Status
        };
    }
}
