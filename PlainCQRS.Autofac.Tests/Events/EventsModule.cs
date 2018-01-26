using Autofac;
using PlainCQRS.Core.Events;

namespace PlainCQRS.Autofac.Tests.Events
{
    public class EventsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c =>
            {
                var threadSpecificContext = c.Resolve<IComponentContext>();
                return new EventDispatcher(threadSpecificContext);
            })
            .As<IEventPublisher>()
            .InstancePerDependency();

            builder.Register(c =>
            {
                var threadSpecificContext = c.Resolve<IComponentContext>();
                return new EventDispatcherAsync(threadSpecificContext);
            })
            .As<IEventPublisherAsync>()
            .InstancePerDependency();

            builder.RegisterType<TestEventHandler>().As<IEventHandler<TestEvent>>().InstancePerDependency();
            builder.RegisterType<TestEventHandlerAsync>().As<IEventHandlerAsync<TestEvent>>().InstancePerDependency();
        }
    }
}