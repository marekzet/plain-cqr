using Autofac;
using PlainCQRS.Core.Commands;

namespace PlainCQRS.Autofac.Tests.Commands
{
    public class CommandsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c =>
            {
                var threadSpecificContext = c.Resolve<IComponentContext>();
                return new CommandDispatcher(threadSpecificContext);
            })
            .As<ICommandSender>()
            .InstancePerDependency();

            builder.Register(c =>
            {
                var threadSpecificContext = c.Resolve<IComponentContext>();
                return new CommandDispatcherAsync(threadSpecificContext);
            })
            .As<ICommandSenderAsync>()
            .InstancePerDependency();

            builder.RegisterType<TestCommandHandler>().As<ICommandHandler<TestCommand>>().InstancePerDependency();
            builder.RegisterType<TestCommandHandlerAsync>().As<ICommandHandlerAsync<TestCommand>>().InstancePerDependency();
        }
    }
}