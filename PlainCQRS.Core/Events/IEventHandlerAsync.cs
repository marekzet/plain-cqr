using System.Threading;
using System.Threading.Tasks;

namespace PlainCQRS.Core.Events
{
    /// <summary>
    ///     Defines a handler that asynchronously handles an event.
    /// </summary>
    /// <typeparam name="TEvent">The type of event being handled.</typeparam>
    public interface IEventHandlerAsync<in TEvent> where TEvent : IEvent
    {
        /// <summary>
        ///     Handles an event.
        /// </summary>
        /// <param name="event">The event</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A task that represents an asynchronous operation.</returns>
        Task HandleAsync(TEvent @event, CancellationToken cancellationToken = default(CancellationToken));
    }
}