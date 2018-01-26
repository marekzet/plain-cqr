namespace PlainCQRS.Core.Events
{
    /// <summary>
    ///     Defines a handler that synchronously handles an event.
    /// </summary>
    /// <typeparam name="TEvent">The type of event being handled.</typeparam>
    public interface IEventHandler<TEvent> where TEvent : IEvent
    {
        /// <summary>
        ///     Handles an event.
        /// </summary>
        /// <param name="event">The event</param>
        void Handle(TEvent @event);
    }
}