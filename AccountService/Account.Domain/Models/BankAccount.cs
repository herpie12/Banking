using System;

namespace Account.Domain.Models
{
   public class BankAccount
    {

        public int Id { get; private set; }

        public int AccountNo { get; set; }

        public string AccountType { get; set; }

        public AccountStatus Status { get; set; }

        public decimal Balance { get; set; }

        public DateTime Created { get; set; }

        public BankAccount(int accountNo, string accountType, AccountStatus status, decimal balance, DateTime created)
        {
            AccountNo = accountNo;
            AccountType = accountType;
            Status = status;
            Balance = balance;
            Created = created;
        }

        public void Close()
        {
            if (Status is AccountStatus.Closed)
                return;

            Status = AccountStatus.Closed;
        }
    }
}
