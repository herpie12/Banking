using System;

namespace Account.Infrastructure.BackgroundJobs.Events
{
    public class BaseEvent
    {
        public Guid Id { get; private set; }
        public DateTime CreationDate { get; private set; }

        public BaseEvent()
        {
            Id = Guid.NewGuid(); ;
            CreationDate = DateTime.UtcNow;
        }
    }
}
