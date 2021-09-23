using MediatR;

namespace Account.Application.Commands
{
    public class WithdrawCommand : IRequest<decimal>
    {
        public decimal Amount { get; set; }
        public int AccountId { get; set; }

        public WithdrawCommand(decimal amount, int accountId)
        {
            Amount = amount;
            AccountId = accountId;
        }
    }
}
