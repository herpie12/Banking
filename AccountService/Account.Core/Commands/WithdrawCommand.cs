using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.Commands
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
