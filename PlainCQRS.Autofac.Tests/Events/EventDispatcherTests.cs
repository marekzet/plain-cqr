using PlainCQRS.Core.Events;
using System;
using System.Threading.Tasks;
using Xunit;

namespace PlainCQRS.Autofac.Tests.Events
{
    public class EventDispatcherTests : AutofacTest<EventsModule>, IDisposable
    {
        [Fact]
        public void should_publish_event_using_registered_handler()
        {
            var @event = new TestEvent();

            var eventBus = Resolve<IEventPublisher>();

            eventBus.Publish(@event);
        }

        [Fact]
        public async Task should_publish_event_asynchronously_using_registered_handler()
        {
            var @event = new TestEvent();

            var eventBus = Resolve<IEventPublisherAsync>();

            await eventBus.PublishAsync(@event);
        }

        public void Dispose()
        {
            CleanUpContainer();
        }
    }
}