using MediatR;

namespace Account.Services.Commands
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
