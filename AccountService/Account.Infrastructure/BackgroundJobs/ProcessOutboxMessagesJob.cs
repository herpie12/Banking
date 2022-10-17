using Account.Domain.Models;
using Account.Infrastructure.Data.Context;
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
        //private readonly IPublisher _publisher;

        public ProcessOutboxMessagesJob(BankAccountDbContext bankAccountDbContext )
        {
            _bankAccountDbContext = bankAccountDbContext;
            //_publisher = publisher; 
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

                //_publisher.Publish(domainEvent);

                message.ProcessedOnUtc = DateTime.UtcNow;

                await _bankAccountDbContext.SaveChangesAsync();
            }
        }
    }
}
