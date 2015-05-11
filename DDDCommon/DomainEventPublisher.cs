using System;
using System.Collections.Generic;
using System.Linq;

namespace DDDCommon
{
    public class DomainEventPublisher
    {
        [ThreadStatic]
        static DomainEventPublisher _instance;

        public static DomainEventPublisher Instance
        {
            get { return _instance ?? (_instance = new DomainEventPublisher()); }
        }

        List<IDomainEventSubscriber<IDomainEvent>> subscribers;
        List<IDomainEventSubscriber<IDomainEvent>> Subscribers
        {
            get { return subscribers ?? (subscribers = new List<IDomainEventSubscriber<IDomainEvent>>()); }
        }

        public void Publish<T>(T domainEvent) where T : IDomainEvent
        {
            var matchedSubscribers = Subscribers.Where(sub => IsEventTypeMatch(domainEvent, sub)).ToList();
            matchedSubscribers.ForEach(sub => sub.HandleEvent(domainEvent));
        }

        private static bool IsEventTypeMatch<T>(T domainEvent, IDomainEventSubscriber<IDomainEvent> subscriber) where T : IDomainEvent
        {
            return domainEvent.GetType() == subscriber.SubscribedToEventType();
        }

        public void Reset()
        {
            subscribers = null;
        }

        public void Subscribe(IDomainEventSubscriber<IDomainEvent> subscriber)
        {
            Subscribers.Add(subscriber);
        }
    }
}