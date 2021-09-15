using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Account.AccountApi.RequestModels
{
    public class AccountWithdraw
    {
        public int AccountId { get; set; }
        public decimal Amount { get; set; }
    }
}
