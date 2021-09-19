namespace Account.AccountApi.RequestModels
{
    public class AccountWithdraw
    {
        public int AccountId { get; set; }
        public decimal Amount { get; set; }
    }
}
