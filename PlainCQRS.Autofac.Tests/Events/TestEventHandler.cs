using PlainCQRS.Core.Events;

namespace PlainCQRS.Autofac.Tests.Events
{
    public class TestEventHandler : IEventHandler<TestEvent>
    {
        public void Handle(TestEvent @event)
        {
        }
    }
}