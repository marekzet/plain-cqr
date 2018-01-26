using Autofac;
using PlainCQRS.Core.Common;
using PlainCQRS.Core.Events;
using System.Collections.Generic;

namespace PlainCQRS.Autofac
{
    /// <summary>
    ///     Default implementation of synchronous dispatcher for events.
    /// </summary>
    public class EventDispatcher : IEventPublisher
    {
        private readonly IComponentContext componentContext;

        /// <summary>
        ///     Initializes a new instance of the <see cref="EventDispatcher"/> class.
        /// </summary>
        /// <param name="componentContext">The context in which a service can be accessed or a component's dependencies resolved.</param>
        public EventDispatcher(IComponentContext componentContext)
        {
            this.componentContext = componentContext;
        }

        public void Publish<TEvent>(TEvent @event) where TEvent : IEvent
        {
            ICollection<IEventHandler<TEvent>> handlers;
            if (componentContext.TryResolve(out handlers))
            {
                foreach (var handler in handlers)
                {
                    handler.Handle(@event);
                }
            }
            else
            {
                throw new HandlerNotFoundException($"Handler not registered for event: {@event.GetType() }");
            }
        }
    }
}