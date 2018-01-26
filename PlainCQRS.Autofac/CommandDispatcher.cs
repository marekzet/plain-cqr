using Autofac;
using PlainCQRS.Core.Commands;
using PlainCQRS.Core.Common;

namespace PlainCQRS.Autofac
{
    public class CommandDispatcher : ICommandSender
    {
        private readonly IComponentContext componentContext;

        public CommandDispatcher(IComponentContext componentContext)
        {
            this.componentContext = componentContext;
        }

        public void Send<TCommand>(TCommand command) where TCommand : ICommand
        {
            ICommandHandler<TCommand> handler;
            if (componentContext.TryResolve(out handler))
            {
                handler.Handle(command);
            }
            else
            {
                throw new HandlerNotFoundException($"Handler not registered for command: {command.GetType() }");
            }
        }
    }
}