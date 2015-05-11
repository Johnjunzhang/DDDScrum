using System;

namespace DDDCommon
{
    public interface IDomainEventSubscriber<in T> where T : IDomainEvent
    {
        void HandleEvent(T domainEvent);
        Type SubscribedToEventType();
    }
}