using Autofac;
using PlainCQRS.Core.Common;
using PlainCQRS.Core.Events;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PlainCQRS.Autofac
{
    public class EventDispatcherAsync : IEventPublisherAsync
    {
        private readonly IComponentContext componentContext;

        public EventDispatcherAsync(IComponentContext componentContext)
        {
            this.componentContext = componentContext;
        }

        public async Task PublishAsync<TEvent>(TEvent @event, CancellationToken cancellationToken =
            default(CancellationToken)) where TEvent : IEvent
        {
            ICollection<IEventHandlerAsync<TEvent>> asyncHandlers;
            if (componentContext.TryResolve(out asyncHandlers))
            {
                var asyncHandlersTasks = new List<Task>();

                foreach (var asyncHandler in asyncHandlers)
                {
                    asyncHandlersTasks.Add(asyncHandler.HandleAsync(@event));
                }

                await Task.WhenAll(asyncHandlersTasks);
            }
            else
            {
                throw new HandlerNotFoundException($"Handler not registered for event: {@event.GetType() }");
            }
        }
    }
}