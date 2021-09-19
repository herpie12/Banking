using Account.Domain.Models;

namespace Account.Services.DtoModels
{
    public sealed class AccountDto
    {
        public int AccountNo { get; set; }

        public string AccountType { get; set; }

        public AccountStatus Status { get; set; }

        public decimal Balance { get; set; }

    }
}
