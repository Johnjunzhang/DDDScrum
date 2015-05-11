using System;

namespace DDDCommon
{
    class DomainEventSubscriber<TEvent> : IDomainEventSubscriber<TEvent>
        where TEvent : IDomainEvent
    {
        public DomainEventSubscriber(Action<TEvent> handle)
        {
            this.handle = handle;
        }

        readonly Action<TEvent> handle;

        public void HandleEvent(TEvent domainEvent)
        {
            handle(domainEvent);
        }

        public Type SubscribedToEventType()
        {
            return typeof(TEvent);
        }
    }
}