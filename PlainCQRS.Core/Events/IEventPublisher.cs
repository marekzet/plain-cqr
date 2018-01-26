namespace PlainCQRS.Core.Events
{
    /// <summary>
    ///     Defines a synchronous dispatcher for events.
    /// </summary>
    public interface IEventPublisher
    {
        /// <summary>
        ///     Synchronously sends event to one or more handlers.
        /// </summary>
        /// <typeparam name="TEvent">Event type.</typeparam>
        /// <param name="event">Event object.</param>
        void Publish<TEvent>(TEvent @event) where TEvent : IEvent;
    }
}