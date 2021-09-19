using Account.Services.Commands;
using Account.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Account.Services.CommandHandlers
{
    public class WithdrawHandler : IRequestHandler<WithdrawCommand, decimal>
    {
        private readonly IBankAccountRepository _bankAccountRepository;

        public WithdrawHandler(IBankAccountRepository bankAccountRepository)
        {
            _bankAccountRepository = bankAccountRepository;
        }

        public async Task<decimal> Handle(WithdrawCommand request, CancellationToken cancellationToken)
        {
            return await _bankAccountRepository.Withdraw(request.Amount, request.AccountId);
        }
    }
}
