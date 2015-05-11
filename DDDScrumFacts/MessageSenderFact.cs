using System;
using DDDCommon;
using DDDNotification;
using DDDScrum;
using Xunit;

namespace DDDScrumFacts
{
    public class MessageSenderFact
    {
        [Fact]
        public void should_send_notification_when_backlogitem_is_committed()
        {
            var sendNotificationDomainEventSubscriber = new SendNotificationDomainEventSubscriber();
            DomainEventPublisher.Instance.Reset();
            DomainEventPublisher.Instance.Subscribe(sendNotificationDomainEventSubscriber);

            var product = new Product("ScrumDDD");
            var sprint = product.Schedule("Sprint1", new DateTime(2015, 1, 1), new DateTime(2015, 1, 15));

            var backLogItem = product.Plan("this is a story");

            backLogItem.CommitTo(sprint);
            Assert.Equal("backLogItem:[this is a story] has been committed to sprint:[Sprint1]", FakeMessageSender.Message);
        } 
    }
}