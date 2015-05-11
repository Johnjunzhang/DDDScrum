using System;
using DDDCommon;
using DDDScrum;

namespace DDDNotification
{
    public class SendNotificationDomainEventSubscriber : IDomainEventSubscriber<IDomainEvent>
    {
        public void HandleEvent(IDomainEvent domainEvent)
        {
            var backLogCommited = (BackLogCommitedEvent)domainEvent;
            FakeMessageSender.Send(backLogCommited.BackLogItemName, backLogCommited.SprintName);
        }

        public Type SubscribedToEventType()
        {
            return typeof(BackLogCommitedEvent);
        }
    }
}