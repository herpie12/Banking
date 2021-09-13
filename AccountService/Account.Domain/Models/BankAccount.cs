using System;

namespace Account.Domain.Models
{
   public class BankAccount
    {
        public int Id { get; set; }

        public int AccountNo { get; set; }

        public string AccountType { get; set; }

        public string Status { get; set; }

        public DateTime Created { get; set; }

    }
}
