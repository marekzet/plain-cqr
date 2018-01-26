using Autofac;
using PlainCQRS.Core.Commands;
using PlainCQRS.Core.Events;
using PlainCQRS.Core.Queries;

namespace PlainCQRS.Autofac
{
    public class AspNetCoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            RegisterQueryDispatchers(builder);
            RegisterCommandDispatchers(builder);
            RegisterEventDispatchers(builder);
        }

        private static void RegisterEventDispatchers(ContainerBuilder builder)
        {
            builder.Register(c =>
            {
                var threadSpecificContext = c.Resolve<IComponentContext>();
                return new EventDispatcher(threadSpecificContext);
            })
            .As<IEventPublisher>()
            .InstancePerLifetimeScope();

            builder.Register(c =>
            {
                var threadSpecificContext = c.Resolve<IComponentContext>();
                return new EventDispatcherAsync(threadSpecificContext);
            })
            .As<IEventPublisherAsync>()
            .InstancePerLifetimeScope();
        }

        private static void RegisterCommandDispatchers(ContainerBuilder builder)
        {
            builder.Register(c =>
            {
                var threadSpecificContext = c.Resolve<IComponentContext>();
                return new CommandDispatcher(threadSpecificContext);
            })
            .As<ICommandSender>()
            .InstancePerLifetimeScope();

            builder.Register(c =>
            {
                var threadSpecificContext = c.Resolve<IComponentContext>();
                return new CommandDispatcherAsync(threadSpecificContext);
            })
            .As<ICommandSenderAsync>()
            .InstancePerLifetimeScope();
        }

        private static void RegisterQueryDispatchers(ContainerBuilder builder)
        {
            builder.Register(c =>
            {
                var threadSpecificContext = c.Resolve<IComponentContext>();
                return new QueryDispatcher(threadSpecificContext);
            })
            .As<IQueryDispatcher>()
            .InstancePerLifetimeScope();

            builder.Register(c =>
            {
                var threadSpecificContext = c.Resolve<IComponentContext>();
                return new QueryDispatcherAsync(threadSpecificContext);
            })
            .As<IQueryDispatcherAsync>()
            .InstancePerLifetimeScope();
        }
    }
}