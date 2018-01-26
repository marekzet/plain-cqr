using Autofac;
using PlainCQRS.Core.Common;
using PlainCQRS.Core.Events;
using System.Collections.Generic;

namespace PlainCQRS.Autofac
{
    public class EventDispatcher : IEventPublisher
    {
        private readonly IComponentContext componentContext;

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