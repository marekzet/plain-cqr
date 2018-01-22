using System.Threading;
using System.Threading.Tasks;

namespace PlainCQRS.Core.Events
{
    public interface IEventPublisherAsync
    {
        Task PublishAsync<TEvent>(TEvent @event, CancellationToken cancellationToken = default(CancellationToken))
            where TEvent : IEvent;
    }
}