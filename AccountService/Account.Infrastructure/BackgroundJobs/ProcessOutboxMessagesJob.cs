using Account.Domain.Models;
using Account.Infrastructure.BackgroundJobs.Events;
using Account.Infrastructure.Data.Context;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Quartz;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Account.Infrastructure.BackgroundJobs
{
    [DisallowConcurrentExecution]
    public class ProcessOutboxMessagesJob : IJob
    {
        private readonly BankAccountDbContext _bankAccountDbContext;
        private readonly IPublishEndpoint _publishEndpoint;
        //private readonly IPublisher _publisher;

        public ProcessOutboxMessagesJob(BankAccountDbContext bankAccountDbContext, IPublishEndpoint publishEndpoint)
        {
            _bankAccountDbContext = bankAccountDbContext;

            _publishEndpoint = publishEndpoint ?? throw new ArgumentNullException(nameof(publishEndpoint));
        }
        public async Task Execute(IJobExecutionContext context)
        {
            var messages = await _bankAccountDbContext.Set<AccountOutBoxMessage>()
                            .Where(m => m.ProcessedOnUtc == null)
                            .Take(20).ToListAsync();

            foreach (var message in messages)
            {
                var domainEvent = JsonConvert.DeserializeObject<BankAccount>(message.Content);

                if (domainEvent is null)
                {
                    continue;
                    //logging
                }

               await _publishEndpoint.Publish(new AccountEvent {
                        AccountNo = domainEvent.AccountNo,
                        AccountType = domainEvent.AccountType,
                        Balance = domainEvent.Balance,
                        AccountCreated = domainEvent.Created,
                        Status = domainEvent.Status});

                message.ProcessedOnUtc = DateTime.UtcNow;

                await _bankAccountDbContext.SaveChangesAsync();
            }
        }
    }
}
