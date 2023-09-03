using System;
namespace Account.Domain.Models
{
    public class AccountOutBoxMessage 
    {
        public Guid Id { get; set; }
        public string Content { get; set; } 
        public DateTime OccurredOnUtc { get; set; }
        public DateTime? ProcessedOnUtc { get; set; }
        public string Error { get; set; }
    }
}
