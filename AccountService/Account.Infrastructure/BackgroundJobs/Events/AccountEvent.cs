using Account.Domain.Models;
using System;

namespace Account.Infrastructure.BackgroundJobs.Events
{
    public class AccountEvent : BaseEvent
    {
        public int AccountNo { get; set; }

        public string AccountType { get; set; }

        public AccountStatus Status { get; set; }

        public decimal Balance { get; set; }

        public DateTime AccountCreated { get; set; }

    }
}
