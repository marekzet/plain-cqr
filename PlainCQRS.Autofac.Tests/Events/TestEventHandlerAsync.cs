using PlainCQRS.Core.Events;
using System.Threading;
using System.Threading.Tasks;

namespace PlainCQRS.Autofac.Tests.Events
{
    public class TestEventHandlerAsync : IEventHandlerAsync<TestEvent>
    {
        public Task HandleAsync(TestEvent @event, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.FromResult(0);
        }
    }
}