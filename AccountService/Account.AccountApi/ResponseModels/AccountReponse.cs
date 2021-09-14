namespace Account.AccountApi.ResponseModels
{
    public class AccountReponse
    {
        public int AccountNo { get; set; }

        public string AccountType { get; set; }

        public string Status { get; set; }

        public decimal Balance { get; set; }
    }
}
