using System;
using System.Collections.Generic;

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

        DomainEventPublisher()
        {
            publishing = false;
        }

        bool publishing;

        List<IDomainEventSubscriber<IDomainEvent>> subscribers;
        List<IDomainEventSubscriber<IDomainEvent>> Subscribers
        {
            get { return subscribers ?? (subscribers = new List<IDomainEventSubscriber<IDomainEvent>>()); }
            set
            {
                subscribers = value;
            }
        }

        public void Publish<T>(T domainEvent) where T : IDomainEvent
        {
            if (publishing || !HasSubscribers()) return;
            try
            {
                publishing = true;

                var eventType = domainEvent.GetType();

                foreach (var subscriber in Subscribers)
                {
                    var subscribedToType = subscriber.SubscribedToEventType();
                    if (eventType == subscribedToType || subscribedToType == typeof(IDomainEvent))
                    {
                        subscriber.HandleEvent(domainEvent);
                    }
                }
            }
            finally
            {
                publishing = false;
            }
        }

        public void PublishAll(ICollection<IDomainEvent> domainEvents)
        {
            foreach (var domainEvent in domainEvents)
            {
                Publish(domainEvent);
            }
        }

        public void Reset()
        {
            if (!publishing)
            {
                Subscribers = null;
            }
        }

        public void Subscribe(IDomainEventSubscriber<IDomainEvent> subscriber)
        {
            if (!publishing)
            {
                Subscribers.Add(subscriber);
            }
        }

        public void Subscribe(Action<IDomainEvent> handle)
        {
            Subscribe(new DomainEventSubscriber<IDomainEvent>(handle));
        }

        bool HasSubscribers()
        {
            return subscribers != null && Subscribers.Count != 0;
        }
    }
}