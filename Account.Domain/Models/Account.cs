using System;

namespace Account.Domain.Models
{
   public class Account
    {
        public int Id { get; set; }

        public int AccountNo { get; set; }

        public string Type { get; set; }

        public string Status { get; set; }

        public DateTime Created { get; set; }

    }
}
