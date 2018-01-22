using System.Threading;
using System.Threading.Tasks;

namespace PlainCQRS.Core.Events
{
    public interface IEventHandlerAsync<in TEvent> where TEvent : IEvent
    {
        Task HandleAsync(TEvent @event, CancellationToken cancellationToken = default(CancellationToken));
    }
}