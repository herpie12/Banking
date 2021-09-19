using System;

namespace Account.Domain.Models
{
    public class BankAccount
    {

        public int Id { get; private set; }

        public int AccountNo { get; set; }

        public string AccountType { get; set; }

        public AccountStatus Status { get; set; }

        public decimal Balance { get; private set; }

        public DateTime Created { get; set; }

        public void Close()
        {
            if (Status is AccountStatus.Closed)
                return;

            Status = AccountStatus.Closed;
        }

        public BankAccount(int accountNo, string accountType, AccountStatus status, decimal balance, DateTime created)
        {
            AccountNo = accountNo;
            AccountType = accountType;
            Status = status;
            Balance = balance;
            Created = created;
        }

        public void SetBalance(decimal balance)
        {
            if (0 > balance)
            {
                throw new ArgumentException("Invalid balance. "  + balance);
            }
            Balance = balance;
        }
        public decimal Withdraw(decimal amount)
        {
            if (amount > Balance)
            {
                throw new ArgumentException("Withdraw from Balance is not possible, balance is: " + Balance + " and withdraw amount is: " + amount);
            }

            var newBalance = Balance -= amount;

            return newBalance;
        }
    }
}
