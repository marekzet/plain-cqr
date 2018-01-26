using System.Threading;
using System.Threading.Tasks;

namespace PlainCQRS.Core.Events
{
    /// <summary>
    ///     Defines an asynchronous dispatcher for events.
    /// </summary>
    public interface IEventPublisherAsync
    {
        /// <summary>
        ///     Asynchronously sends event to one or more handlers.
        /// </summary>
        /// <typeparam name="TEvent">Event type.</typeparam>
        /// <param name="event">Event object.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A task that represents an asynchronous operation.</returns>
        Task PublishAsync<TEvent>(TEvent @event, CancellationToken cancellationToken = default(CancellationToken))
            where TEvent : IEvent;
    }
}